﻿using System;
using System.Diagnostics;
using Csla;
using System.Linq;

namespace MyCsla
{
  /// <summary>
  /// Adds posibbility of Logging/Instrumentation of DataPortal calls on BusinessObjects that does not use the ObjectFactoryAttribute
  /// 
  /// Consider f.ex the possiblity of creating PerformanceCounters and logging of Exceptions to EventLog.  
  /// </summary>
  /// <typeparam name="T"></typeparam>
  [Serializable]
  public class BusinessBase<T> : Csla.BusinessBase<T> where T : BusinessBase<T>
  {
    /// <summary>
    /// Called by the server-side DataPortal prior to calling the
    /// requested DataPortal_XYZ method.
    /// </summary>
    /// <param name="e">The DataPortalContext object passed to the DataPortal.</param>
    protected override void DataPortal_OnDataPortalInvoke(DataPortalEventArgs e)
    {
      Trace.TraceInformation("DataPortalInvoke object:{0}, operation:{1}", e.ObjectType, e.Operation);
      base.DataPortal_OnDataPortalInvoke(e);
    }

    /// <summary>
    /// Called by the server-side DataPortal after calling the
    /// requested DataPortal_XYZ method.
    /// </summary>
    /// <param name="e">The DataPortalContext object passed to the DataPortal.</param>
    protected override void DataPortal_OnDataPortalInvokeComplete(DataPortalEventArgs e)
    {
      Trace.TraceInformation("DataPortalInvokeCompleted object:{0}, operation:{1}", e.ObjectType, e.Operation);
      base.DataPortal_OnDataPortalInvokeComplete(e);
    }

    /// <summary>
    /// Called by the server-side DataPortal if an exception
    /// occurs during data access.
    /// </summary>
    /// <param name="e">The DataPortalContext object passed to the DataPortal.</param>
    /// <param name="ex">The Exception thrown during data access.</param>
    protected override void DataPortal_OnDataPortalException(DataPortalEventArgs e, Exception ex)
    {
      Trace.TraceError("DataPortalException(object:{0}, operation:{1}, exception:{2}", e.ObjectType, e.Operation, ex);
      base.DataPortal_OnDataPortalException(e, ex);
    }


    /// <summary>
    /// Added helper method to get ProperyInfo for a string PropertyName 
    /// </summary>
    /// <param name="propertyName">Name of the property.</param>
    /// <returns>IPropertyInfo object or null if not found</returns>
    internal Csla.Core.IPropertyInfo GetPropertyInfo(string propertyName)
    {
      // check if has registered fields 
      if (!FieldManager.HasFields) return null;

      // Linq query on FieldManager
      return FieldManager.GetRegisteredProperties().Where(p => p.Name == propertyName).FirstOrDefault();
    }


  }
}