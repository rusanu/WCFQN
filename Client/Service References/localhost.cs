﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.832
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.localhost
{
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://rusanu.com/Samples/WCFQN", ConfigurationName="Client.localhost.WCFQNTableSubscribe", CallbackContract=typeof(Client.localhost.WCFQNTableSubscribeCallback), SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface WCFQNTableSubscribe
    {
        
        // CODEGEN: Parameter 'cookie' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://rusanu.com/Samples/WCFQN/WCFQNTableSubscribe/Subscribe")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        void Subscribe(Client.localhost.Subscribe request);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface WCFQNTableSubscribeCallback
    {
        
        // CODEGEN: Parameter 'cookie' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://rusanu.com/Samples/WCFQN/WCFQNTableSubscribe/Callback")]
        [System.ServiceModel.XmlSerializerFormatAttribute()]
        void Callback(Client.localhost.Callback request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Subscribe", WrapperNamespace="http://rusanu.com/Samples/WCFQN", IsWrapped=true)]
    public partial class Subscribe
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://rusanu.com/Samples/WCFQN", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string cookie;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://rusanu.com/Samples/WCFQN", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string sql;
        
        public Subscribe()
        {
        }
        
        public Subscribe(string cookie, string sql)
        {
            this.cookie = cookie;
            this.sql = sql;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Callback", WrapperNamespace="http://rusanu.com/Samples/WCFQN", IsWrapped=true)]
    public partial class Callback
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://rusanu.com/Samples/WCFQN", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string cookie;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://rusanu.com/Samples/WCFQN", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Data.DataSet data;
        
        public Callback()
        {
        }
        
        public Callback(string cookie, System.Data.DataSet data)
        {
            this.cookie = cookie;
            this.data = data;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface WCFQNTableSubscribeChannel : Client.localhost.WCFQNTableSubscribe, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class WCFQNTableSubscribeClient : System.ServiceModel.DuplexClientBase<Client.localhost.WCFQNTableSubscribe>, Client.localhost.WCFQNTableSubscribe
    {
        
        public WCFQNTableSubscribeClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance)
        {
        }
        
        public WCFQNTableSubscribeClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName)
        {
        }
        
        public WCFQNTableSubscribeClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress)
        {
        }
        
        public WCFQNTableSubscribeClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress)
        {
        }
        
        public WCFQNTableSubscribeClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress)
        {
        }
        
        void Client.localhost.WCFQNTableSubscribe.Subscribe(Client.localhost.Subscribe request)
        {
            base.Channel.Subscribe(request);
        }
        
        public void Subscribe(string cookie, string sql)
        {
            Client.localhost.Subscribe inValue = new Client.localhost.Subscribe();
            inValue.cookie = cookie;
            inValue.sql = sql;
            ((Client.localhost.WCFQNTableSubscribe)(this)).Subscribe(inValue);
        }
    }
}
