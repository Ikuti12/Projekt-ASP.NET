﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by coded UI test builder.
//      Version: 15.0.0.0
//
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------

namespace CodedUITestProject2
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using System.Windows.Input;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;
    
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public partial class UIMap
    {
        
        /// <summary>
        /// AdminLogIn - Use 'AdminLogInParams' to pass parameters into this method.
        /// </summary>
        public void AdminLogIn()
        {
            #region Variable Declarations
            WinListItem uIFirefoxListItem = this.UIProgramManagerWindow.UIPulpitList.UIFirefoxListItem;
            WinComboBox uIItemComboBox = this.UIMozillaFirefoxWindow.UIPaseknarzędzinawigacToolBar.UIItemComboBox;
            WinEdit uIWprowadźadreslubszukEdit = this.UIMozillaFirefoxWindow.UIItemComboBox.UIWprowadźadreslubszukEdit;
            WinEdit uILoginEdit = this.UIMozillaFirefoxWindow.UILoginHyperlink.UILoginEdit;
            WinEdit uIUsernameEdit = this.UIMozillaFirefoxWindow.UIItemDocument.UIUsernameEdit;
            WinEdit uIPasswordEdit = this.UIMozillaFirefoxWindow.UIItemDocument.UIPasswordEdit;
            WinButton uILoginButton = this.UIMozillaFirefoxWindow.UIItemDocument.UILoginButton;
            WinHyperlink uIManageCategoriesHyperlink = this.UIMozillaFirefoxWindow.UIManageCategoriesListItem.UIManageCategoriesHyperlink;
            #endregion

            // Double-Click 'Firefox' list item
            Mouse.DoubleClick(uIFirefoxListItem, new Point(51, 34));

            // Select 'http://localhost:63418/' in combo box
            uIItemComboBox.EditableItem = this.AdminLogInParams.UIItemComboBoxEditableItem;

            // Type '{Enter}' in 'Wprowadź adres lub szukaj w Google' text box
            Keyboard.SendKeys(uIWprowadźadreslubszukEdit, this.AdminLogInParams.UIWprowadźadreslubszukEditSendKeys, ModifierKeys.None);

            // Click 'Log in' text box
            Mouse.Click(uILoginEdit, new Point(19, 11));

            // Type 'Admin' in 'User name' text box
            uIUsernameEdit.Text = this.AdminLogInParams.UIUsernameEditText;

            // Type '{Tab}' in 'User name' text box
            Keyboard.SendKeys(uIUsernameEdit, this.AdminLogInParams.UIUsernameEditSendKeys, ModifierKeys.None);

            // Type '********' in 'Password' text box
            Keyboard.SendKeys(uIPasswordEdit, this.AdminLogInParams.UIPasswordEditSendKeys, true);

            // Click 'Log in' button
            Mouse.Click(uILoginButton, new Point(46, 16));

            // Click 'Manage Categories' link
            Mouse.Click(uIManageCategoriesHyperlink, new Point(35, 33));
        }
        
        #region Properties
        public virtual AdminLogInParams AdminLogInParams
        {
            get
            {
                if ((this.mAdminLogInParams == null))
                {
                    this.mAdminLogInParams = new AdminLogInParams();
                }
                return this.mAdminLogInParams;
            }
        }
        
        public UIProgramManagerWindow UIProgramManagerWindow
        {
            get
            {
                if ((this.mUIProgramManagerWindow == null))
                {
                    this.mUIProgramManagerWindow = new UIProgramManagerWindow();
                }
                return this.mUIProgramManagerWindow;
            }
        }
        
        public UIMozillaFirefoxWindow UIMozillaFirefoxWindow
        {
            get
            {
                if ((this.mUIMozillaFirefoxWindow == null))
                {
                    this.mUIMozillaFirefoxWindow = new UIMozillaFirefoxWindow();
                }
                return this.mUIMozillaFirefoxWindow;
            }
        }
        #endregion
        
        #region Fields
        private AdminLogInParams mAdminLogInParams;
        
        private UIProgramManagerWindow mUIProgramManagerWindow;
        
        private UIMozillaFirefoxWindow mUIMozillaFirefoxWindow;
        #endregion
    }
    
    /// <summary>
    /// Parameters to be passed into 'AdminLogIn'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class AdminLogInParams
    {
        
        #region Fields
        /// <summary>
        /// Select 'http://localhost:63418/' in combo box
        /// </summary>
        public string UIItemComboBoxEditableItem = "http://localhost:63418/";
        
        /// <summary>
        /// Type '{Enter}' in 'Wprowadź adres lub szukaj w Google' text box
        /// </summary>
        public string UIWprowadźadreslubszukEditSendKeys = "{Enter}";
        
        /// <summary>
        /// Type 'Admin' in 'User name' text box
        /// </summary>
        public string UIUsernameEditText = "Admin";
        
        /// <summary>
        /// Type '{Tab}' in 'User name' text box
        /// </summary>
        public string UIUsernameEditSendKeys = "{Tab}";
        
        /// <summary>
        /// Type '********' in 'Password' text box
        /// </summary>
        public string UIPasswordEditSendKeys = "8LkfRdwPx81+BvOdXGdCtfAL+Dcv75XlkzI+Vs5lLuLsGcGSWTS25QPs0e5LA4IF";
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class UIProgramManagerWindow : WinWindow
    {
        
        public UIProgramManagerWindow()
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.Name] = "Program Manager";
            this.SearchProperties[WinWindow.PropertyNames.ClassName] = "Progman";
            this.WindowTitles.Add("Program Manager");
            #endregion
        }
        
        #region Properties
        public UIPulpitList UIPulpitList
        {
            get
            {
                if ((this.mUIPulpitList == null))
                {
                    this.mUIPulpitList = new UIPulpitList(this);
                }
                return this.mUIPulpitList;
            }
        }
        #endregion
        
        #region Fields
        private UIPulpitList mUIPulpitList;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class UIPulpitList : WinList
    {
        
        public UIPulpitList(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinList.PropertyNames.Name] = "Pulpit";
            this.WindowTitles.Add("Program Manager");
            #endregion
        }
        
        #region Properties
        public WinListItem UIFirefoxListItem
        {
            get
            {
                if ((this.mUIFirefoxListItem == null))
                {
                    this.mUIFirefoxListItem = new WinListItem(this);
                    #region Search Criteria
                    this.mUIFirefoxListItem.SearchProperties[WinListItem.PropertyNames.Name] = "Firefox";
                    this.mUIFirefoxListItem.WindowTitles.Add("Program Manager");
                    #endregion
                }
                return this.mUIFirefoxListItem;
            }
        }
        #endregion
        
        #region Fields
        private WinListItem mUIFirefoxListItem;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class UIMozillaFirefoxWindow : WinWindow
    {
        
        public UIMozillaFirefoxWindow()
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.Name] = "Mozilla Firefox";
            this.SearchProperties[WinWindow.PropertyNames.ClassName] = "MozillaWindowClass";
            this.WindowTitles.Add("Mozilla Firefox");
            #endregion
        }
        
        #region Properties
        public UIPaseknarzędzinawigacToolBar UIPaseknarzędzinawigacToolBar
        {
            get
            {
                if ((this.mUIPaseknarzędzinawigacToolBar == null))
                {
                    this.mUIPaseknarzędzinawigacToolBar = new UIPaseknarzędzinawigacToolBar(this);
                }
                return this.mUIPaseknarzędzinawigacToolBar;
            }
        }
        
        public UIItemComboBox UIItemComboBox
        {
            get
            {
                if ((this.mUIItemComboBox == null))
                {
                    this.mUIItemComboBox = new UIItemComboBox(this);
                }
                return this.mUIItemComboBox;
            }
        }
        
        public UILoginHyperlink UILoginHyperlink
        {
            get
            {
                if ((this.mUILoginHyperlink == null))
                {
                    this.mUILoginHyperlink = new UILoginHyperlink(this);
                }
                return this.mUILoginHyperlink;
            }
        }
        
        public UIItemDocument UIItemDocument
        {
            get
            {
                if ((this.mUIItemDocument == null))
                {
                    this.mUIItemDocument = new UIItemDocument(this);
                }
                return this.mUIItemDocument;
            }
        }
        
        public UIManageCategoriesListItem UIManageCategoriesListItem
        {
            get
            {
                if ((this.mUIManageCategoriesListItem == null))
                {
                    this.mUIManageCategoriesListItem = new UIManageCategoriesListItem(this);
                }
                return this.mUIManageCategoriesListItem;
            }
        }
        #endregion
        
        #region Fields
        private UIPaseknarzędzinawigacToolBar mUIPaseknarzędzinawigacToolBar;
        
        private UIItemComboBox mUIItemComboBox;
        
        private UILoginHyperlink mUILoginHyperlink;
        
        private UIItemDocument mUIItemDocument;
        
        private UIManageCategoriesListItem mUIManageCategoriesListItem;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class UIPaseknarzędzinawigacToolBar : WinToolBar
    {
        
        public UIPaseknarzędzinawigacToolBar(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinToolBar.PropertyNames.Name] = "Pasek narzędzi nawigacyjnych";
            this.WindowTitles.Add("Mozilla Firefox");
            #endregion
        }
        
        #region Properties
        public WinComboBox UIItemComboBox
        {
            get
            {
                if ((this.mUIItemComboBox == null))
                {
                    this.mUIItemComboBox = new WinComboBox(this);
                    #region Search Criteria
                    this.mUIItemComboBox.WindowTitles.Add("Mozilla Firefox");
                    #endregion
                }
                return this.mUIItemComboBox;
            }
        }
        #endregion
        
        #region Fields
        private WinComboBox mUIItemComboBox;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class UIItemComboBox : WinComboBox
    {
        
        public UIItemComboBox(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.WindowTitles.Add("Mozilla Firefox");
            #endregion
        }
        
        #region Properties
        public WinEdit UIWprowadźadreslubszukEdit
        {
            get
            {
                if ((this.mUIWprowadźadreslubszukEdit == null))
                {
                    this.mUIWprowadźadreslubszukEdit = new WinEdit(this);
                    #region Search Criteria
                    this.mUIWprowadźadreslubszukEdit.SearchProperties[WinEdit.PropertyNames.Name] = "Wprowadź adres lub szukaj w Google";
                    this.mUIWprowadźadreslubszukEdit.WindowTitles.Add("Mozilla Firefox");
                    #endregion
                }
                return this.mUIWprowadźadreslubszukEdit;
            }
        }
        #endregion
        
        #region Fields
        private WinEdit mUIWprowadźadreslubszukEdit;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class UILoginHyperlink : WinHyperlink
    {
        
        public UILoginHyperlink(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinHyperlink.PropertyNames.Name] = "Log in";
            this.WindowTitles.Add("Mozilla Firefox");
            #endregion
        }
        
        #region Properties
        public WinEdit UILoginEdit
        {
            get
            {
                if ((this.mUILoginEdit == null))
                {
                    this.mUILoginEdit = new WinEdit(this);
                    #region Search Criteria
                    this.mUILoginEdit.SearchProperties[WinEdit.PropertyNames.Name] = "Log in";
                    this.mUILoginEdit.WindowTitles.Add("Mozilla Firefox");
                    #endregion
                }
                return this.mUILoginEdit;
            }
        }
        #endregion
        
        #region Fields
        private WinEdit mUILoginEdit;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class UIItemDocument : WinControl
    {
        
        public UIItemDocument(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[UITestControl.PropertyNames.ControlType] = "Document";
            this.WindowTitles.Add("Mozilla Firefox");
            #endregion
        }
        
        #region Properties
        public WinEdit UIUsernameEdit
        {
            get
            {
                if ((this.mUIUsernameEdit == null))
                {
                    this.mUIUsernameEdit = new WinEdit(this);
                    #region Search Criteria
                    this.mUIUsernameEdit.SearchProperties[WinEdit.PropertyNames.Name] = "User name";
                    this.mUIUsernameEdit.WindowTitles.Add("Mozilla Firefox");
                    #endregion
                }
                return this.mUIUsernameEdit;
            }
        }
        
        public WinEdit UIPasswordEdit
        {
            get
            {
                if ((this.mUIPasswordEdit == null))
                {
                    this.mUIPasswordEdit = new WinEdit(this);
                    #region Search Criteria
                    this.mUIPasswordEdit.SearchProperties[WinEdit.PropertyNames.Name] = "Password";
                    this.mUIPasswordEdit.WindowTitles.Add("Mozilla Firefox");
                    #endregion
                }
                return this.mUIPasswordEdit;
            }
        }
        
        public WinButton UILoginButton
        {
            get
            {
                if ((this.mUILoginButton == null))
                {
                    this.mUILoginButton = new WinButton(this);
                    #region Search Criteria
                    this.mUILoginButton.SearchProperties[WinButton.PropertyNames.Name] = "Log in";
                    this.mUILoginButton.WindowTitles.Add("Mozilla Firefox");
                    #endregion
                }
                return this.mUILoginButton;
            }
        }
        #endregion
        
        #region Fields
        private WinEdit mUIUsernameEdit;
        
        private WinEdit mUIPasswordEdit;
        
        private WinButton mUILoginButton;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class UIManageCategoriesListItem : WinListItem
    {
        
        public UIManageCategoriesListItem(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinListItem.PropertyNames.Name] = "Manage Categories";
            this.WindowTitles.Add("Mozilla Firefox");
            #endregion
        }
        
        #region Properties
        public WinHyperlink UIManageCategoriesHyperlink
        {
            get
            {
                if ((this.mUIManageCategoriesHyperlink == null))
                {
                    this.mUIManageCategoriesHyperlink = new WinHyperlink(this);
                    #region Search Criteria
                    this.mUIManageCategoriesHyperlink.SearchProperties[WinHyperlink.PropertyNames.Name] = "Manage Categories";
                    this.mUIManageCategoriesHyperlink.WindowTitles.Add("Mozilla Firefox");
                    #endregion
                }
                return this.mUIManageCategoriesHyperlink;
            }
        }
        #endregion
        
        #region Fields
        private WinHyperlink mUIManageCategoriesHyperlink;
        #endregion
    }
}