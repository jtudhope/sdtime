﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18034
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace sdtime.CWTicketService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Ticket", Namespace="http://schemas.datacontract.org/2004/07/SD.CWServices.Model.Tickets")]
    [System.SerializableAttribute()]
    public partial class Ticket : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AssignedMemberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int AssignedMemberIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ClientIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ClientNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double HoursActualField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double HoursBudgetField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StatusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int StatusIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int TicketIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TitleField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string AssignedMember {
            get {
                return this.AssignedMemberField;
            }
            set {
                if ((object.ReferenceEquals(this.AssignedMemberField, value) != true)) {
                    this.AssignedMemberField = value;
                    this.RaisePropertyChanged("AssignedMember");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int AssignedMemberId {
            get {
                return this.AssignedMemberIdField;
            }
            set {
                if ((this.AssignedMemberIdField.Equals(value) != true)) {
                    this.AssignedMemberIdField = value;
                    this.RaisePropertyChanged("AssignedMemberId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ClientID {
            get {
                return this.ClientIDField;
            }
            set {
                if ((this.ClientIDField.Equals(value) != true)) {
                    this.ClientIDField = value;
                    this.RaisePropertyChanged("ClientID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ClientName {
            get {
                return this.ClientNameField;
            }
            set {
                if ((object.ReferenceEquals(this.ClientNameField, value) != true)) {
                    this.ClientNameField = value;
                    this.RaisePropertyChanged("ClientName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double HoursActual {
            get {
                return this.HoursActualField;
            }
            set {
                if ((this.HoursActualField.Equals(value) != true)) {
                    this.HoursActualField = value;
                    this.RaisePropertyChanged("HoursActual");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double HoursBudget {
            get {
                return this.HoursBudgetField;
            }
            set {
                if ((this.HoursBudgetField.Equals(value) != true)) {
                    this.HoursBudgetField = value;
                    this.RaisePropertyChanged("HoursBudget");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Status {
            get {
                return this.StatusField;
            }
            set {
                if ((object.ReferenceEquals(this.StatusField, value) != true)) {
                    this.StatusField = value;
                    this.RaisePropertyChanged("Status");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int StatusID {
            get {
                return this.StatusIDField;
            }
            set {
                if ((this.StatusIDField.Equals(value) != true)) {
                    this.StatusIDField = value;
                    this.RaisePropertyChanged("StatusID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int TicketID {
            get {
                return this.TicketIDField;
            }
            set {
                if ((this.TicketIDField.Equals(value) != true)) {
                    this.TicketIDField = value;
                    this.RaisePropertyChanged("TicketID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Title {
            get {
                return this.TitleField;
            }
            set {
                if ((object.ReferenceEquals(this.TitleField, value) != true)) {
                    this.TitleField = value;
                    this.RaisePropertyChanged("Title");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Status", Namespace="http://schemas.datacontract.org/2004/07/SD.CWServices.Model.Tickets")]
    [System.SerializableAttribute()]
    public partial class Status : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SortOrderField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int StatusIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TitleField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int SortOrder {
            get {
                return this.SortOrderField;
            }
            set {
                if ((this.SortOrderField.Equals(value) != true)) {
                    this.SortOrderField = value;
                    this.RaisePropertyChanged("SortOrder");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int StatusID {
            get {
                return this.StatusIDField;
            }
            set {
                if ((this.StatusIDField.Equals(value) != true)) {
                    this.StatusIDField = value;
                    this.RaisePropertyChanged("StatusID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Title {
            get {
                return this.TitleField;
            }
            set {
                if ((object.ReferenceEquals(this.TitleField, value) != true)) {
                    this.TitleField = value;
                    this.RaisePropertyChanged("Title");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CWTicketService.ITicketService")]
    public interface ITicketService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITicketService/GetTicketsForTheWeek", ReplyAction="http://tempuri.org/ITicketService/GetTicketsForTheWeekResponse")]
        System.Collections.Generic.List<sdtime.CWTicketService.Ticket> GetTicketsForTheWeek(System.Collections.Generic.List<System.Nullable<int>> members, System.Collections.Generic.List<System.Nullable<int>> clients, int serviceBoard);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITicketService/GetStatus", ReplyAction="http://tempuri.org/ITicketService/GetStatusResponse")]
        System.Collections.Generic.List<sdtime.CWTicketService.Status> GetStatus(int serviceBoard);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITicketService/SetTicket", ReplyAction="http://tempuri.org/ITicketService/SetTicketResponse")]
        bool SetTicket(sdtime.CWTicketService.Ticket ticket);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITicketServiceChannel : sdtime.CWTicketService.ITicketService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TicketServiceClient : System.ServiceModel.ClientBase<sdtime.CWTicketService.ITicketService>, sdtime.CWTicketService.ITicketService {
        
        public TicketServiceClient() {
        }
        
        public TicketServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TicketServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TicketServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TicketServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.List<sdtime.CWTicketService.Ticket> GetTicketsForTheWeek(System.Collections.Generic.List<System.Nullable<int>> members, System.Collections.Generic.List<System.Nullable<int>> clients, int serviceBoard) {
            return base.Channel.GetTicketsForTheWeek(members, clients, serviceBoard);
        }
        
        public System.Collections.Generic.List<sdtime.CWTicketService.Status> GetStatus(int serviceBoard) {
            return base.Channel.GetStatus(serviceBoard);
        }
        
        public bool SetTicket(sdtime.CWTicketService.Ticket ticket) {
            return base.Channel.SetTicket(ticket);
        }
    }
}
