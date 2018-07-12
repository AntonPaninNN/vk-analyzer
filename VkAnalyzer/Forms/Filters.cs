using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VkAnalyzer.Events;
using VkAnalyzer.Events.Events;

namespace VkAnalyzer.Forms
{
    public partial class Filters : Form
    {
        private ISubscriber _subscriber = null;

        public Filters(ISubscriber subscriber)
        {
            _subscriber = subscriber;
            InitializeComponent();
        }

        private void _saveFiltersBtn_Click(object sender, EventArgs e)
        {
            _subscriber.onEvent(new FiltersEvent(prepareParameters()));
            this.Close();
        }

        private Dictionary<string, string> prepareParameters()
        {
            /* FIRST NAME */
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(_firstNameTb.Text))
                parameters.Add("FirstName", _firstNameTb.Text);
            
            /* LAST NAME */
            if (!string.IsNullOrEmpty(_secondNameTb.Text))
                parameters.Add("LastName", _secondNameTb.Text);
            
            /* SEX */
            if (!string.IsNullOrEmpty(_sexTb.Text))
                parameters.Add("Sex", _sexTb.Text);
            
            /* CITY */
            if (!string.IsNullOrEmpty(_cityTb.Text))
                parameters.Add("City", _cityTb.Text);

            /* KIDS */
            if (!string.IsNullOrEmpty(_kidsCb.Text))
                parameters.Add("HasChilds", _kidsCb.Text);

            /* HAS MOBILE */
            if (!string.IsNullOrEmpty(_mobileCb.Text))
                parameters.Add("MobileExists", _mobileCb.Text);

            /* ONLINE */
            if (!string.IsNullOrEmpty(_onlineCb.Text))
                parameters.Add("IsOnline", _onlineCb.Text);

            /* RELATION */
            if (!string.IsNullOrEmpty(_familyCb.Text))
                parameters.Add("Family", _familyCb.Text);

            /* STATUS */
            if (!string.IsNullOrEmpty(_statusTb.Text))
                parameters.Add("Status", _statusTb.Text);

            /* B-DAY */
            if (!string.IsNullOrEmpty(_fromBDayTp.Text) && 
                !string.IsNullOrEmpty(_toBDayTp.Text)   &&
                !_fromBDayTp.Text.Equals(_toBDayTp.Text))
                parameters.Add("BDate", _fromBDayTp.Text + "---" + _toBDayTp.Text);

            /* Add other fields */

            return parameters;
        }

    }
}
