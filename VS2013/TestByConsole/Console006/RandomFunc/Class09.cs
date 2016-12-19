using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console006.RandomFunc
{
  /// <summary>
  /// 比较两个相同类型的对象的差异
  /// </summary>
  class C9
  {
    public static void Execute(string[] args)
    {
      User U1 = new User();
      U1.UserName = "ZhangShan";
      U1.Age = 12;
      U1.Address = new UserAddress() { State="GuangDong", City="GZ" };

      User U2 = new User();
      U2.UserName = "LiShi";
      U2.Age = 12;
      U2.Address = new UserAddress() { State="GuangDong", City="CZ" };

      UserCompare UC = UserCompare.CompareUserDiff(U1, U2);
      Console.WriteLine(UC.UserNameDiff);
      Console.WriteLine(UC.AgeDiff);
      Console.WriteLine(UC.AddressDiff.StateDiff);
      Console.WriteLine(UC.AddressDiff.CityDiff);
    }

    private class User
    {
      public string UserName { get; set; }
      public int Age { get; set; }
      public UserAddress Address { get; set; }
    }

    private class UserAddress
    {
      public string State { get; set; }
      public string City { get; set; }
    }

    private class UserCompare
    {
      public bool UserNameDiff { get; set; }
      public bool AgeDiff { get; set; }
      public UserAddressCompare AddressDiff { get; set; }

      public static UserCompare CompareUserDiff(User U1, User U2)
      {
        UserCompare UC = new UserCompare();

        //Check UserName
        UC.UserNameDiff = !U1.UserName.Equals(U2.UserName, StringComparison.Ordinal);

        //Check Age
        UC.AgeDiff = !(U1.Age == U2.Age);

        UC.AddressDiff = UserAddressCompare.CompareUserAddressDiff(U1.Address, U2.Address);
        return UC;
      }
    }

    private class UserAddressCompare
    {
      public bool StateDiff { get; set; }
      public bool CityDiff { get; set; }

      public static UserAddressCompare CompareUserAddressDiff(UserAddress UA1, UserAddress UA2)
      {
        UserAddressCompare UAC = new UserAddressCompare();
        UAC.StateDiff = !UA1.State.Equals(UA2.State, StringComparison.Ordinal);
        UAC.CityDiff = !UA2.City.Equals(UA2.City, StringComparison.Ordinal);
        return UAC;
      }
    }
  }
}
