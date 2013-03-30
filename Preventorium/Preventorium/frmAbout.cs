using System.Reflection;
using System.Windows.Forms;

namespace Preventorium
{

    /// <summary>
    /// Форма окна "О программе".
    /// </summary>
    partial class frmAbout : Form
    {

        /// <summary>
        /// Иницииализирует форму окна "О программе".
        /// </summary>
        public frmAbout()
        {
            InitializeComponent();
            this.Text = string.Format("О программе \"{0}\" ...", AssemblyProduct);
            lblMainInfo.Text = string.Format("{0} (v. {1})", AssemblyProduct, AssemblyVersion);
            lblMainInfo.Text += string.Format("\nРазработка (на базе {0}):", AssemblyCompany);
            lblMainInfo.Text += string.Format("\n     Бабурин Д. (гр. 4/42)");
            lblMainInfo.Text += string.Format("\n     Петров И. (гр. 4/42)");
            lblMainInfo.Text += string.Format("\nРуководитель:");
            lblMainInfo.Text += string.Format("\n     асс. Смирнов С.С.");
            lblMainInfo.Text += string.Format("\n\n{0}", AssemblyCopyright);
            txtDescription.Text = AssemblyDescription;
        }

        #region Методы доступа к атрибутам сборки

        /// <summary>
        /// Возвращает заголовок проекта.
        /// </summary>
        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }
        /// <summary>
        /// Возвращает текущую весрию проекта.
        /// </summary>
        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }
        /// <summary>
        /// Возвращает описание проекта.
        /// </summary>
        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }
        /// <summary>
        /// Возвращает название проекта.
        /// </summary>
        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }
        /// <summary>
        /// Возвращает информацию о копирайтах.
        /// </summary>
        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }
        /// <summary>
        /// Возвращает название компании разработчика.
        /// </summary>
        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }

        #endregion

    }

}
