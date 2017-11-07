using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using RBI.DAL.MSSQL_CAL;
using System.Diagnostics;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Design;
using DevExpress.XtraTreeList.Menu;
using DevExpress.XtraTreeList.Nodes;
namespace RBI
{
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
            list = dataSource();
            SetupTree(list);
            //treeList1.OptionsView.ShowIndicator = false;
            //treeList1.OptionsView.ShowColumns = false;
            //treeList1.OptionsView.ShowHorzLines = false;
            //treeList1.OptionsView.ShowVertLines = false;
            //focusTree();
            treeList1.ExpandAll();
        }
        private int selectedLevel = -1;
        private String selectedData;

        List<TEST_SITE> listRoot;
        List<TEST_FACILITY> listChild_1;
        List<TEST_EQUIPMENT> listChild_2;
        List<TEST_COMPONENT> listChild_3;

        /// <summary>
        /// test data
        /// -------site table------------
        /// 1   -1  Cortek
        /// 2   -1  RBI
        /// 3   -1  VuNA
        /// -------facility table-----------
        /// 1   1   Test1
        /// 2   1   Test2
        /// 3   2   Test3
        /// 4   3   Test4
        /// -------equipment table------------
        /// 1   1   Eq1
        /// 2   1   Eq2
        /// 3   2   Eq3
        /// 4   3   Eq4
        /// 5   4   Eq5
        /// -------component table------------
        /// 1   1   com1
        /// 2   2   com2
        /// 3   3   com3
        /// 4   4   com4
        /// 5   5   com5
        /// ----------------------------------
        /// site: 0
        /// facility: 100000
        /// equipment: 200000
        /// component: 300000
        /// </summary>
        private void setupData()
        {
            listRoot = new List<TEST_SITE>();
            listChild_1 = new List<TEST_FACILITY>();
            listChild_2 = new List<TEST_EQUIPMENT>();
            listChild_3 = new List<TEST_COMPONENT>();

            listRoot.Add(new TEST_SITE(1, "Cortek"));
            listRoot.Add(new TEST_SITE(2, "RBI"));
            listRoot.Add(new TEST_SITE(3, "VuNA"));

            listChild_1.Add(new TEST_FACILITY(100000 + 1, 1, "Test1"));
            listChild_1.Add(new TEST_FACILITY(100000 + 2, 1, "Test2"));
            listChild_1.Add(new TEST_FACILITY(100000 + 3, 2, "Test3"));
            listChild_1.Add(new TEST_FACILITY(100000 + 4, 3, "Test4"));

            listChild_2.Add(new TEST_EQUIPMENT(200000 + 1, 100000 + 1, "Eq1"));
            listChild_2.Add(new TEST_EQUIPMENT(200000 + 2, 100000 + 1, "Eq2"));
            listChild_2.Add(new TEST_EQUIPMENT(200000 + 3, 100000 + 2, "Eq3"));
            listChild_2.Add(new TEST_EQUIPMENT(200000 + 4, 100000 + 3, "Eq4"));
            listChild_2.Add(new TEST_EQUIPMENT(200000 + 5, 100000 + 4, "Eq5"));

            listChild_3.Add(new TEST_COMPONENT(300000 + 1, 200000 + 1, "com1"));
            listChild_3.Add(new TEST_COMPONENT(300000 + 2, 200000 + 2, "com2"));
            listChild_3.Add(new TEST_COMPONENT(300000 + 3, 200000 + 3, "com3"));
            listChild_3.Add(new TEST_COMPONENT(300000 + 4, 200000 + 4, "com4"));
            listChild_3.Add(new TEST_COMPONENT(300000 + 5, 200000 + 5, "com5"));
        }
        
        private List<TestData> list;
        private List<TestData> dataSource()
        {
            setupData();
            list = new List<TestData>();
            for (int i = 0; i < listRoot.Count; i++)
            {
                list.Add(new TestData(listRoot[i].SiteID, listRoot[i].ParentID, listRoot[i].SiteName));
            }
            for (int i = 0; i < listChild_1.Count; i++)
            {
                list.Add(new TestData(listChild_1[i].FacilityID, listChild_1[i].SiteID, listChild_1[i].FacilityName));
            }
            for (int i = 0; i < listChild_2.Count; i++)
            {
                list.Add(new TestData(listChild_2[i].equipmentID, listChild_2[i].facilityID, listChild_2[i].equipmentName));
            }
            for (int i = 0; i < listChild_3.Count; i++)
            {
                list.Add(new TestData(listChild_3[i].componentID, listChild_3[i].equipmentID, listChild_3[i].componentName));
            }
            return list;
        }
        private void SetupTree(List<TestData> list)
        {
            treeList1.DataSource = list;
            treeList1.OptionsBehavior.Editable = false;
            //for(int i = 0; i< list.Count; i++)
            //{
            //    if (list[i].ParentID == -1)
            //        treeList1.FocusedNode.StateImageIndex = 0;
            //    else if (list[i].ParentID == 0)
            //        treeList1.FocusedNode.StateImageIndex = 1;
            //    else
            //        treeList1.FocusedNode.StateImageIndex = 2;
            //}
        }
        private void focusTree()
        {
            TreeListNode node = treeList1.FocusedNode;
            if (node.Nodes != null)
            {
                foreach (TreeListNode item in node.Nodes)
                {
                    if (item.Level == 0)
                    {
                        item.StateImageIndex = 0;
                    }
                    else if (item.Level == 1)
                    {
                        item.StateImageIndex = 1;
                    }
                    else if (item.Level == 2)
                    {
                        item.StateImageIndex = 2;
                    }
                    else
                        item.StateImageIndex = 3;
                }

            }
        }

        private void treeList1_GetStateImage(object sender, DevExpress.XtraTreeList.GetStateImageEventArgs e)
        {

        }


        private void TreeListForm_Load(object sender, EventArgs e)
        {
            //focusTree();
            list = dataSource();
            SetupTree(list);
            treeList1.OptionsView.ShowIndicator = false;
            treeList1.OptionsView.ShowColumns = false;
            treeList1.OptionsView.ShowHorzLines = false;
            treeList1.OptionsView.ShowVertLines = false;
            treeList1.ExpandAll();
        }

        private void treeList1_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            TreeListNode node = treeList1.FocusedNode;
            foreach (TreeListNode item in node.Nodes)
            {
                if (e.Node.Level == 0)
                {
                    e.Node.StateImageIndex = 0;
                }
                else if (e.Node.Level == 1)
                {
                    e.Node.StateImageIndex = 1;
                }
                else if (e.Node.Level == 2)
                {
                    e.Node.StateImageIndex = 2;
                }
                else
                    e.Node.StateImageIndex = 3;
            }
            selectedLevel = e.Node.Level;
            selectedData = e.Node.GetValue(0).ToString();
        }

        private void treeList1_CustomDrawNodeImages(object sender, CustomDrawNodeImagesEventArgs e)
        {
            TreeListNode node = treeList1.FocusedNode;
            foreach (TreeListNode item in node.Nodes)
            {
                if (e.Node.Level == 0)
                {
                    e.Node.StateImageIndex = 0;
                    e.Node.SelectImageIndex = 0;
                }
                else if (e.Node.Level == 1)
                {
                    e.Node.StateImageIndex = 1;
                    e.Node.SelectImageIndex = 1;
                }
                else if (e.Node.Level == 2)
                {
                    e.Node.StateImageIndex = 2;
                    e.Node.SelectImageIndex = 2;
                }
                else
                {
                    e.Node.StateImageIndex = 3;
                    e.Node.SelectImageIndex = 3;
                }
            }
        }
        private void treeList1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.Menu is TreeListNodeMenu)
            {
                if (selectedLevel == 0)
                {
                    treeList1.FocusedNode = ((TreeListNodeMenu)e.Menu).Node;
                    e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Add Site", btn_add_site_click));
                    e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Add Facility", btn_add_facility_click));
                }
                else if (selectedLevel == 1)
                {
                    treeList1.FocusedNode = ((TreeListNodeMenu)e.Menu).Node;
                    e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Add Equipment", btn_add_Equipment_click));
                }
                else if (selectedLevel == 2)
                {
                    treeList1.FocusedNode = ((TreeListNodeMenu)e.Menu).Node;
                    e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Add Component", btn_add_Component_click));
                }
                else
                {
                    // do nothing
                }
            }
        }

        private void btn_add_Component_click(object sender, EventArgs e)
        {
            int ID = listChild_3.Max(TEST_COMPONENT => TEST_COMPONENT.componentID) + 1;
            int parent = 0;
            for (int i = 0; i < listChild_2.Count; i++)
            {
                if (selectedData == listChild_2[i].equipmentName)
                    parent = listChild_2[i].equipmentID;
            }
            if (parent != 0)
            {
                listChild_3.Add(new TEST_COMPONENT(ID, parent, "com" + (ID - 300000)));
                list.Add(new TestData(ID, parent, "com" + (ID - 300000)));
                treeList1.DataSource = list;
                treeList1.RefreshDataSource();
            }
            else
            {
                // do nothing
            }
        }

        private void btn_add_Equipment_click(object sender, EventArgs e)
        {
            int ID = listChild_2.Max(TEST_EQUIPMENT => TEST_EQUIPMENT.equipmentID) + 1;
            int parent = 0;
            for (int i = 0; i < listChild_1.Count; i++)
            {
                if (selectedData == listChild_1[i].FacilityName)
                    parent = listChild_1[i].FacilityID;
            }
            if (parent != 0)
            {
                listChild_2.Add(new TEST_EQUIPMENT(ID, parent, "Eq" + (ID - 200000)));
                list.Add(new TestData(ID, parent, "Eq" + (ID - 200000)));
                treeList1.DataSource = list;
                treeList1.RefreshDataSource();
            }
            else
            {
                // do nothing
            }
        }

        private void btn_add_facility_click(object sender, EventArgs e)
        {
            int ID = listChild_1.Max(TEST_FACILITY => TEST_FACILITY.FacilityID) + 1;
            int parent = 0;
            for (int i = 0; i < listRoot.Count; i++)
            {
                if (selectedData == listRoot[i].SiteName)
                    parent = listRoot[i].SiteID;
            }
            if (parent != 0)
            {
                listChild_1.Add(new TEST_FACILITY(ID, parent, "Test" + (ID - 100000)));
                list.Add(new TestData(ID, parent, "Test" + (ID - 100000)));
                treeList1.DataSource = list;
                treeList1.RefreshDataSource();
            }
            else
            {
                // do nothing
            }
        }

        private void btn_add_site_click(object sender, EventArgs e)
        {
            if (selectedLevel != 0)
            {
                // do nothing
            }
            else
            {
                int ID = listRoot.Max(TEST_SITE => TEST_SITE.SiteID) + 1;
                listRoot.Add(new TEST_SITE(ID, "Site" + ID));
                list.Add(new TestData(ID, -1, "Site" + ID));
                treeList1.DataSource = list;
                treeList1.RefreshDataSource();
            }

        }

        private void btn_edit_click(object sender, EventArgs e)
        {
            //treeList1.OptionsBehavior.Editable = !treeList1.OptionsBehavior.Editable;
            //treeList1.ShowEditor();
        }
        private void btn_Add_click(object sender, EventArgs e)
        {
            //int value = list.Max(TestData => TestData.ID);
            //int parentID = treeList1.FocusedNode.Level;
            //if(parentID == 0)
            //list.Add(new TestData(value + 1, parentID, "NEW NODE"));
            //treeList1.DataSource = list;
            //Console.WriteLine(value);
            //treeList1.RefreshDataSource();
        }
    }
}
