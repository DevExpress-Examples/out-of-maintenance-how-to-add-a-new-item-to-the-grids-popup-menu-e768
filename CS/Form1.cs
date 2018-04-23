using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Design.XViewsPrinting v = new DevExpress.XtraGrid.Design.XViewsPrinting(gridControl1);
            gridView1.OptionsView.ShowFooter = true;
        }

        private void gridView1_ShowGridMenu(object sender, DevExpress.XtraGrid.Views.Grid.GridMenuEventArgs e)
        {
            if (e.MenuType != DevExpress.XtraGrid.Views.Grid.GridMenuType.Summary) 
                return;
            DevExpress.XtraGrid.Menu.GridViewFooterMenu footerMenu = e.Menu as DevExpress.XtraGrid.Menu.GridViewFooterMenu;
            DevExpress.Utils.Menu.DXMenuItem menuItem = new DevExpress.Utils.Menu.DXMenuItem("MyItem", new EventHandler(MyMenuItem));
            menuItem.Tag = e.Menu;
            footerMenu.Items.Add(menuItem);
        }
        private void MyMenuItem(Object sender, EventArgs e) {
            DevExpress.Utils.Menu.DXMenuItem Item= sender as DevExpress.Utils.Menu.DXMenuItem;
            DevExpress.XtraGrid.Menu.GridViewFooterMenu menu = Item.Tag as DevExpress.XtraGrid.Menu.GridViewFooterMenu;
            MessageBox.Show(menu.View.FocusedColumn.FieldName);
        }

    }
}