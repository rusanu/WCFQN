using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Data;
using System.Threading;
using System.Data.SqlClient;
using wcfService.Properties;


namespace wcfService
{
    /// <summary>
    /// The main subscription service contract
    /// </summary>
    [ServiceContract(
        Name="WCFQNTableSubscribe",
        Namespace="http://rusanu.com/Samples/WCFQN",
        CallbackContract=typeof(IWCFQNTableCallback),
        SessionMode=SessionMode.Required)]
    public interface IWCFQNTableSubscribe
    {
        [OperationContract(IsOneWay=true)]
        void Subscribe(string cookie, string sql);
    }

    /// <summary>
    /// The callback contract. The dataset is 
    /// sent back to client using this contract
    /// </summary>
    public interface IWCFQNTableCallback
    {
        [OperationContract(IsOneWay = true)]
        void Callback(string cookie, DataSet data);
    }

    /// <summary>
    /// A pre-subscription state object. Each subscribe call
    /// creates a state object that has the cookie, the sql,
    /// the client callback and the local SqlDependency callback
    /// </summary>
    internal class WCFQNRequestState
    {
        private string _cookie;
        private string _sql;
        private IWCFQNTableCallback _callback;

        public WCFQNRequestState(
            string cookie,
            string sql,
            IWCFQNTableCallback callback)
        {
            _cookie = cookie;
            _sql = sql;
            _callback = callback;
        }

        /// <summary>
        /// Starts the subscription. Invokes the passed in SQL
        /// </summary>
        public void SubmitDataRequest()
        {
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder(Settings.Default.connectionString);
            scsb.AsynchronousProcessing = true;
            scsb.Pooling = true;

            SqlConnection conn = new SqlConnection(scsb.ConnectionString);
            conn.Open();

            SqlCommand cmdGetTable = new SqlCommand(_sql, conn);

            // Create the associated SqlDependency
            SqlDependency dep = new SqlDependency(cmdGetTable);
            dep.OnChange += new OnChangeEventHandler(dep_OnChange);

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmdGetTable);
            da.Fill(ds);

            // Send the new dataset back to the client
            // on it's own callback
            _callback.Callback(_cookie, ds);
        }

        /// <summary>
        /// Called by SqlDependency when data has changed
        /// </summary>
        void dep_OnChange(object sender, SqlNotificationEventArgs e)
        {
            Console.WriteLine("Info: {0} Type: {1} Source: {2}",
                e.Info, e.Type, e.Source);
            if (e.Type == SqlNotificationType.Change)
            {
                // Submit the SQL back to the server, 
                SubmitDataRequest();
            };
        }
    }

    /// <summary>
    /// Our WCF service implementation
    /// </summary>
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single)]
    public class WCFQNTableSubscription: IWCFQNTableSubscribe
    {
        /// <summary>
        /// Starts the SqlDependecy handler
        /// </summary>
        public static void Start()
        {
            SqlDependency.Start(Settings.Default.connectionString);
            AppDomain.CurrentDomain.DomainUnload += new EventHandler(CurrentDomain_DomainUnload);
        }

        /// <summary>
        /// Callback when the appdomain is unloaded, stop the SqlDependecy handler
        /// </summary>
        static void CurrentDomain_DomainUnload(object sender, EventArgs e)
        {
            SqlDependency.Stop(Settings.Default.connectionString);
        }

        #region IWCFQNTableSubscribe Members

        public void Subscribe(string cookie, string sql)
        {
            IWCFQNTableCallback callback = OperationContext.Current.GetCallbackChannel<IWCFQNTableCallback>();

            // Create a subscription object to keep track of the request
            WCFQNRequestState subscription = new WCFQNRequestState(
                cookie,
                sql,
                callback);
            // Start the subscription
            subscription.SubmitDataRequest();
        }

        #endregion
    }
}
