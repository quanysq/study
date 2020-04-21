﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace Web001.Webservice
{
  [ServiceContract(Namespace = "")]
  [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
  public class Service1
  {
    // To use HTTP GET, add [WebGet] attribute. (Default ResponseFormat is WebMessageFormat.Json)
    // To create an operation that returns XML,
    //     add [WebGet(ResponseFormat=WebMessageFormat.Xml)],
    //     and include the following line in the operation body:
    //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
    [OperationContract]
    public void DoWork()
    {
      // Add your operation implementation here
      return;
    }

    // Add more operations here and mark them with [OperationContract]
    [OperationContract]
    [WebGet(ResponseFormat = WebMessageFormat.Xml)]
    public string TestCall()
    {
      return "Hello world!";
    }

    [OperationContract]
    [WebInvoke(Method = "POST")]
    public string MemeryTest()
    {
      return "The reason for this bug may be because the number of log is too much, it is relatively slow that read and write data to the page";
    }
  }
}
