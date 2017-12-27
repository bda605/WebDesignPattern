using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CHAP3.Model;
using CHAP3.Service;
using CHAP3.Repository;
using CHAP3.Presentation;
using StructureMap;
namespace CHAP3.User_Experience
{
    public partial class Default : System.Web.UI.Page,IProductListView
    {
        private ProductListPresenter _presenter;

        protected void Page_Init(object sender, EventArgs e)
        {
            _presenter = new ProductListPresenter(this, ObjectFactory.GetInstance<Service.ProductService>());
            this.ddlCustomerType.SelectedIndexChanged += delegate { _presenter.Display(); };
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack != true)
                _presenter.Display();
        }

        public void Display(IList<ProductViewModel> Products)
        {
            rptProducts.DataSource = Products;
            rptProducts.DataBind();
        }

        public CustomerType CustomerType
        {
            get { return (CustomerType)Enum.ToObject(typeof(CustomerType), int.Parse(this.ddlCustomerType.SelectedValue)); }
        }


        public string ErrorMessage
        {
            set { lblErrorMessage.Text = String.Format("<p><strong>Error</strong><br/>{0}<p/>", value); }
        }
    }
}