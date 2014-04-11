using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Client.localhost;
using System.ServiceModel;

namespace Client
{
    /// <summary>
    /// The main form implementes the callback contract
    /// Any object could implement this callback, but whatever
    /// object is used, it must be passed on to the
    /// InstanceContext constructor bellow
    /// </summary>
    public partial class MainForm : Form, localhost.WCFQNTableSubscribeCallback
    {
        /// <summary>
        /// The WCF proxy for the subscription service
        /// </summary>
        private localhost.WCFQNTableSubscribeClient _client;

        public MainForm()
        {
            InitializeComponent();

            // Create the proxy client
            // Because is a duplex channel we need an Instance Context
            InstanceContext ic = new InstanceContext(this);
            _client = new WCFQNTableSubscribeClient(ic);
        }

        private void btnFetch_Click(object sender, EventArgs e)
        {
            // Subscribe to the WCF notification service
            _client.Subscribe(txtCookie.Text, txtSQL.Text);
        }

        private void CallbackInvoke(DataSet ds)
        {
            // This is invoked in the main form thread context
            // so it is safe to update UI elements
            //
            grdViewer.DataSource = ds;
            grdViewer.DataMember = ds.Tables[0].TableName;
        }

        /// <summary>
        /// A delegate type for the context transition between WCF callback
        /// and main form thread
        /// </summary>
        /// <param name="ds"></param>
        private delegate void CallbackInvokeHandler(DataSet ds);

        #region WCFQNTableSubscribeCallback Members

        /// <summary>
        /// This is the callback WCF will invoke when
        /// the service is calling back to notify data changes
        /// </summary>
        /// <param name="request"></param>
        public void Callback(Callback request)
        {
            // Simply pass the callback into the main form 
            // thread context using this.Invoke (). Pass the
            // received DataSet on to be displayed on the grid
            //
            Invoke(new CallbackInvokeHandler(CallbackInvoke), request.data);
        }

        #endregion
    }
}