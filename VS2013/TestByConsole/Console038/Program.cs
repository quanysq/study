using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Console038
{
  class Program
  {
    static void Main(string[] args)
    {
      //NetTcpBinding
      //C1.ExecuteMethod<ILMSService>("net.tcp://192.168.8.96:9876/LMSService.svc/Basic", "GetTechnopediaAuthorizationDetails", new object[] { "MkbekdUXwlkezKXCqXnMD/HbW+PHtby1CTDiNsQpy/tHFxwNou127UOeTYonLMuFU0EfskXClFISYUDLldt1Up1aP/Nws8G75N3qkYcH7x6t7fZGEBEoJVkqjOJCQsoETlMIHMsBGqUx+PUKtnkt8Ju43S6bnGuGB8vvxIKn2rjyv3C8B64L5+qt52mpRzo2dZOBcL4H0C4l3aH9ab40BUUL3xKbtq/0iHTvk/oq4H/LHEtcGOwCi+STdwJKWHmp+SNUjnm5dU/vCZlWgBRDaLUSHOaXfn4C92Yy+V1CxLXg0lG+/S+sp703f+pt8DrOwJEyNFozrOaxwQbZBEv1vMc5+lBbaZCZ064MVKhgwQ38LfK1XyQLDrrdyTbYEaDx9S8Pit8JxkqjlH0Y1ZMcD3s8wd2E+LfRj6kUzAq5iPtQ4gtlrrfWP2+cF83VBdUAyo14u9n4CFaqRu68YOcTDsY8AlzIjT46ZrJBRxxhL5ZGckBphIcyjHpiVpeMZz3Gl7RH2PJEIjC6n+2SUXDd5hec43VdE7lLYZnSy5viTdmN1Bs418kt2O4ZPnieEUfuXtKxJ+pp+EaH40K8PlNScuo2Sui76YzrVchDQn9JCZw=", "eng_superkey" });

      //BasicHttpBinding/WSHttpBinding
      //C2.ExecuteMethod<ILMSService>("http://192.168.8.96:9876/LMSService.svc/Basic", "GetTechnopediaAuthorizationDetails", new object[] { "MkbekdUXwlkezKXCqXnMD/HbW+PHtby1CTDiNsQpy/tHFxwNou127UOeTYonLMuFU0EfskXClFISYUDLldt1Up1aP/Nws8G75N3qkYcH7x6t7fZGEBEoJVkqjOJCQsoETlMIHMsBGqUx+PUKtnkt8Ju43S6bnGuGB8vvxIKn2rjyv3C8B64L5+qt52mpRzo2dZOBcL4H0C4l3aH9ab40BUUL3xKbtq/0iHTvk/oq4H/LHEtcGOwCi+STdwJKWHmp+SNUjnm5dU/vCZlWgBRDaLUSHOaXfn4C92Yy+V1CxLXg0lG+/S+sp703f+pt8DrOwJEyNFozrOaxwQbZBEv1vMc5+lBbaZCZ064MVKhgwQ38LfK1XyQLDrrdyTbYEaDx9S8Pit8JxkqjlH0Y1ZMcD3s8wd2E+LfRj6kUzAq5iPtQ4gtlrrfWP2+cF83VBdUAyo14u9n4CFaqRu68YOcTDsY8AlzIjT46ZrJBRxxhL5ZGckBphIcyjHpiVpeMZz3Gl7RH2PJEIjC6n+2SUXDd5hec43VdE7lLYZnSy5viTdmN1Bs418kt2O4ZPnieEUfuXtKxJ+pp+EaH40K8PlNScuo2Sui76YzrVchDQn9JCZw=", "eng_superkey" });

      //获取方法列表
      C3.Execute();
    }
  }
}
