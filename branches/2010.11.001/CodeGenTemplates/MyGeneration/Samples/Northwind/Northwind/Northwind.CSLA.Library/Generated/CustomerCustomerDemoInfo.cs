
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using System.Configuration;
using System.IO;
using System.ComponentModel;
using System.Collections.Generic;
namespace Northwind.CSLA.Library
{
	public delegate void CustomerCustomerDemoInfoEvent(object sender);
	/// <summary>
	///	CustomerCustomerDemoInfo Generated by MyGeneration using the CSLA Object Mapping template
	/// </summary>
	[Serializable()]
	[TypeConverter(typeof(CustomerCustomerDemoInfoConverter))]
	public partial class CustomerCustomerDemoInfo : ReadOnlyBase<CustomerCustomerDemoInfo>, IDisposable
	{
		public event CustomerCustomerDemoInfoEvent Changed;
		private void OnChange()
		{
			if (Changed != null) Changed(this);
		}
		#region Collection
		protected static List<CustomerCustomerDemoInfo> _AllList = new List<CustomerCustomerDemoInfo>();
		private static Dictionary<string, CustomerCustomerDemoInfo> _AllByPrimaryKey = new Dictionary<string, CustomerCustomerDemoInfo>();
		private static void ConvertListToDictionary()
		{
			List<CustomerCustomerDemoInfo> remove = new List<CustomerCustomerDemoInfo>();
			foreach (CustomerCustomerDemoInfo tmp in _AllList)
			{
				_AllByPrimaryKey[tmp.CustomerID.ToString() + "_" + tmp.CustomerTypeID.ToString()]=tmp; // Primary Key
				remove.Add(tmp);
			}
			foreach (CustomerCustomerDemoInfo tmp in remove)
				_AllList.Remove(tmp);
		}
		internal static void AddList(CustomerCustomerDemoInfoList lst)
		{
			foreach (CustomerCustomerDemoInfo item in lst) _AllList.Add(item);
		}
		public static CustomerCustomerDemoInfo GetExistingByPrimaryKey(string customerID, string customerTypeID)
		{
			ConvertListToDictionary();
			string key = customerID.ToString() + "_" + customerTypeID.ToString();
			if (_AllByPrimaryKey.ContainsKey(key)) return _AllByPrimaryKey[key]; 
			return null;
		}
		#endregion
		#region Business Methods
		private string _ErrorMessage = string.Empty;
		public string ErrorMessage
		{
			get { return _ErrorMessage; }
		}
		protected CustomerCustomerDemo _Editable;
		private IVEHasBrokenRules HasBrokenRules
		{
			get
			{
				IVEHasBrokenRules hasBrokenRules = null;
				if (_Editable != null)
					hasBrokenRules = _Editable.HasBrokenRules;
				return hasBrokenRules;
			}
		}
		private string _CustomerID = string.Empty;
		[System.ComponentModel.DataObjectField(true, true)]
		public string CustomerID
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				if (_MyCustomer != null) _CustomerID = _MyCustomer.CustomerID;
				return _CustomerID;
			}
		}
		private CustomerInfo _MyCustomer;
		[System.ComponentModel.DataObjectField(true, true)]
		public CustomerInfo MyCustomer
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				if (_MyCustomer == null && _CustomerID != null) _MyCustomer = CustomerInfo.Get(_CustomerID);
				return _MyCustomer;
			}
		}
		private string _CustomerTypeID = string.Empty;
		[System.ComponentModel.DataObjectField(true, true)]
		public string CustomerTypeID
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				if (_MyCustomerDemographic != null) _CustomerTypeID = _MyCustomerDemographic.CustomerTypeID;
				return _CustomerTypeID;
			}
		}
		private CustomerDemographicInfo _MyCustomerDemographic;
		[System.ComponentModel.DataObjectField(true, true)]
		public CustomerDemographicInfo MyCustomerDemographic
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				if (_MyCustomerDemographic == null && _CustomerTypeID != null) _MyCustomerDemographic = CustomerDemographicInfo.Get(_CustomerTypeID);
				return _MyCustomerDemographic;
			}
		}
		// TODO: Replace base CustomerCustomerDemoInfo.ToString function as necessary
		/// <summary>
		/// Overrides Base ToString
		/// </summary>
		/// <returns>A string representation of current CustomerCustomerDemoInfo</returns>
		//public override string ToString()
		//{
		//  return base.ToString();
		//}
		// TODO: Check CustomerCustomerDemoInfo.GetIdValue to assure that the ID returned is unique
		/// <summary>
		/// Overrides Base GetIdValue - Used internally by CSLA to determine equality
		/// </summary>
		/// <returns>A Unique ID for the current CustomerCustomerDemoInfo</returns>
		protected override object GetIdValue()
		{
			return (_CustomerID.ToString()+"."+_CustomerTypeID.ToString()).GetHashCode();
		}
		#endregion
		#region Factory Methods
		private CustomerCustomerDemoInfo()
		{/* require use of factory methods */
			_AllList.Add(this);
		}
		public void Dispose()
		{
			_AllList.Remove(this);
			_AllByPrimaryKey.Remove(CustomerID.ToString() + "_" + CustomerTypeID.ToString());
		}
		public virtual CustomerCustomerDemo Get()
		{
			return _Editable = CustomerCustomerDemo.Get(_CustomerID, _CustomerTypeID);
		}
		public static void Refresh(CustomerCustomerDemo tmp)
		{
			CustomerCustomerDemoInfo tmpInfo = GetExistingByPrimaryKey(tmp.CustomerID, tmp.CustomerTypeID);
			if (tmpInfo == null) return;
			tmpInfo.RefreshFields(tmp);
		}
		private void RefreshFields(CustomerCustomerDemo tmp)
		{
			_CustomerCustomerDemoInfoExtension.Refresh(this);
			_MyCustomer = null;
			_MyCustomerDemographic = null;
			OnChange();// raise an event
		}
		public static void Refresh(CustomerDemographic myCustomerDemographic, CustomerDemographicCustomerCustomerDemo tmp)
		{
			CustomerCustomerDemoInfo tmpInfo = GetExistingByPrimaryKey(tmp.CustomerID, myCustomerDemographic.CustomerTypeID);
			if (tmpInfo == null) return;
			tmpInfo.RefreshFields(tmp);
		}
		private void RefreshFields(CustomerDemographicCustomerCustomerDemo tmp)
		{
			_CustomerCustomerDemoInfoExtension.Refresh(this);
			_MyCustomer = null;
			_MyCustomerDemographic = null;
			OnChange();// raise an event
		}
		public static void Refresh(Customer myCustomer, CustomerCustomerCustomerDemo tmp)
		{
			CustomerCustomerDemoInfo tmpInfo = GetExistingByPrimaryKey(myCustomer.CustomerID, tmp.CustomerTypeID);
			if (tmpInfo == null) return;
			tmpInfo.RefreshFields(tmp);
		}
		private void RefreshFields(CustomerCustomerCustomerDemo tmp)
		{
			_CustomerCustomerDemoInfoExtension.Refresh(this);
			_MyCustomer = null;
			_MyCustomerDemographic = null;
			OnChange();// raise an event
		}
		public static CustomerCustomerDemoInfo Get(string customerID, string customerTypeID)
		{
			//if (!CanGetObject())
			//  throw new System.Security.SecurityException("User not authorized to view a CustomerCustomerDemo");
			try
			{
				CustomerCustomerDemoInfo tmp = GetExistingByPrimaryKey(customerID, customerTypeID);
				if (tmp == null)
				{
					tmp = DataPortal.Fetch<CustomerCustomerDemoInfo>(new PKCriteria(customerID, customerTypeID));
					_AllList.Add(tmp);
				}
				if (tmp.ErrorMessage == "No Record Found") tmp = null;
				return tmp;
			}
			catch (Exception ex)
			{
				throw new DbCslaException("Error on CustomerCustomerDemoInfo.Get", ex);
			}
		}
		#endregion
		#region Data Access Portal
		internal CustomerCustomerDemoInfo(SafeDataReader dr)
		{
			Database.LogInfo("CustomerCustomerDemoInfo.Constructor", GetHashCode());
			try
			{
				ReadData(dr);
			}
			catch (Exception ex)
			{
				Database.LogException("CustomerCustomerDemoInfo.Constructor", ex);
				throw new DbCslaException("CustomerCustomerDemoInfo.Constructor", ex);
			}
		}
		[Serializable()]
		protected class PKCriteria
		{
			private string _CustomerID;
			public string CustomerID
			{ get { return _CustomerID; } }
			private string _CustomerTypeID;
			public string CustomerTypeID
			{ get { return _CustomerTypeID; } }
			public PKCriteria(string customerID, string customerTypeID)
			{
				_CustomerID = customerID;
				_CustomerTypeID = customerTypeID;
			}
		}
		private void ReadData(SafeDataReader dr)
		{
			Database.LogInfo("CustomerCustomerDemoInfo.ReadData", GetHashCode());
			try
			{
				_CustomerID = dr.GetString("CustomerID");
				_CustomerTypeID = dr.GetString("CustomerTypeID");
			}
			catch (Exception ex)
			{
				Database.LogException("CustomerCustomerDemoInfo.ReadData", ex);
				_ErrorMessage = ex.Message;
				throw new DbCslaException("CustomerCustomerDemoInfo.ReadData", ex);
			}
		}
		private void DataPortal_Fetch(PKCriteria criteria)
		{
			Database.LogInfo("CustomerCustomerDemoInfo.DataPortal_Fetch", GetHashCode());
			try
			{
				using (SqlConnection cn = Database.Northwind_SqlConnection)
				{
					ApplicationContext.LocalContext["cn"] = cn;
					using (SqlCommand cm = cn.CreateCommand())
					{
						cm.CommandType = CommandType.StoredProcedure;
						cm.CommandText = "getCustomerCustomerDemo";
						cm.Parameters.AddWithValue("@CustomerID", criteria.CustomerID);
						cm.Parameters.AddWithValue("@CustomerTypeID", criteria.CustomerTypeID);
						using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
						{
							if (!dr.Read())
							{
								_ErrorMessage = "No Record Found";
								return;
							}
							ReadData(dr);
						}
					}
					// removing of item only needed for local data portal
					if (ApplicationContext.ExecutionLocation == ApplicationContext.ExecutionLocations.Client)
						ApplicationContext.LocalContext.Remove("cn");
				}
			}
			catch (Exception ex)
			{
				Database.LogException("CustomerCustomerDemoInfo.DataPortal_Fetch", ex);
				_ErrorMessage = ex.Message;
				throw new DbCslaException("CustomerCustomerDemoInfo.DataPortal_Fetch", ex);
			}
		}
		#endregion
		// Standard Refresh
		#region extension
		CustomerCustomerDemoInfoExtension _CustomerCustomerDemoInfoExtension = new CustomerCustomerDemoInfoExtension();
		[Serializable()]
		partial class CustomerCustomerDemoInfoExtension : extensionBase {}
		[Serializable()]
		class extensionBase
		{
			// Default Refresh
			public virtual void Refresh(CustomerCustomerDemoInfo tmp) { }
		}
		#endregion
	} // Class
	#region Converter
	internal class CustomerCustomerDemoInfoConverter : ExpandableObjectConverter
	{
		public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destType)
		{
			if (destType == typeof(string) && value is CustomerCustomerDemoInfo)
			{
				// Return the ToString value
				return ((CustomerCustomerDemoInfo)value).ToString();
			}
			return base.ConvertTo(context, culture, value, destType);
		}
	}
	#endregion
} // Namespace
