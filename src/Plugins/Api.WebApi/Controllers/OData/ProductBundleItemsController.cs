﻿using SmartStore.Core.Domain.Catalog;
using SmartStore.Services.Catalog;
using SmartStore.Web.Framework.WebApi;
using SmartStore.Web.Framework.WebApi.OData;
using SmartStore.Web.Framework.WebApi.Security;
using System.Web.Http;

namespace SmartStore.Plugin.Api.WebApi.Controllers.OData
{
	[WebApiAuthenticate(Permission = "ManageCatalog")]
	public class ProductBundleItemsController : WebApiEntityController<ProductBundleItem, IProductService>
	{
		protected override void Insert(ProductBundleItem entity)
		{
			Service.InsertBundleItem(entity);
		}
		protected override void Update(ProductBundleItem entity)
		{
			Service.UpdateBundleItem(entity);
		}
		protected override void Delete(ProductBundleItem entity)
		{
			Service.DeleteBundleItem(entity);
		}

		[WebApiQueryable]
		public SingleResult<ProductBundleItem> GetProductBundleItem(int key)
		{
			return GetSingleResult(key);
		}		

		// navigation properties

		public Product GetProduct(int key)
		{
			return GetExpandedProperty<Product>(key, x => x.Product);
		}

		public Product GetBundleProduct(int key)
		{
			return GetExpandedProperty<Product>(key, x => x.BundleProduct);
		}
	}
}
