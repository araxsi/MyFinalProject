using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;
        

        public ProductManager(IProductDal productDal,ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
            
        }
        [SecuredOperation("product.add,admin")]
        
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            //bir kategoryde satedece 10 ürün olması gerekiyor kuralının işlenmesi
            //Hatalı bir çalışmadır. İş kuralları her zaman değişkendir ve güncellenebilir. Bu sebeble işlenmiş ve düzenlenmiş olması gereklidir
            //var result = _productDal.GetAll(p => p.CategoryId == product.CategoryId).Count;
            //if (result >= 10)
            //{
            //    return new ErrorResult(Messages.ProductCountOfCategoryError);
            //}
            //3 kuraldır..Eğer mevcut kategori sayısı 15'i geçtiyse sisteme yeni ürün eklenemez kuralını yazınız.


            //business codes

            //Validation
            IResult result= BusinessRules.Run(CheckIfProductNameTheSame(product.ProductName), CheckIfProductCountofCategoryCorrect(product.CategoryId), 
                CheckIfCategoryLimitExceded());

            if (result !=null)
            {
                return result;
            }

            
                    _productDal.Add(product);
                    return new SuccessResult(Messages.ProductAdded);
            }

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        public IResult Update(Product product)
        {
            throw new NotImplementedException();
        }

        //Yukarıdaki kuralın temiz ve doğru halidir.
        private IResult CheckIfProductCountofCategoryCorrect (int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 10)
        {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
        }
            return new SuccessResult();
        }
        //2 Kural : Aynı isimde ürün eklenemez. 
        private IResult CheckIfProductNameTheSame(string productname)
        {
            var result = _productDal.GetAll(p => p.ProductName == productname).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }
        //3 kural kodu aşağıdaki gibidir.
        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count > 15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }

            return new SuccessResult();
        }


    }
}