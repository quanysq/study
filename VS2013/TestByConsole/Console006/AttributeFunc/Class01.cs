using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console006.Class;

namespace Console006.AttributeFunc
{
  /// <summary>
  /// 测试获取特性数据1
  /// </summary>
  [BoardingCheck("a", "b", 0, 1, "c", "d")]
  public class C1
  {
    public static void Execute()
    {
      BoardingCheckAttribute boardingCheck = null;
      object[] customAttributes = typeof(C1).GetCustomAttributes(true);

      foreach (var attribute in customAttributes)
      {
        if (attribute is BoardingCheckAttribute)
        {
          boardingCheck = attribute as BoardingCheckAttribute;

          Console.WriteLine(boardingCheck.Name
                      + "'s ID is "
                      + boardingCheck.ID
                      + ", he/she wants to "
                      + boardingCheck.Destination
                      + " from "
                      + boardingCheck.Departure
                      + " by the plane "
                      + boardingCheck.FlightNumber
                      + ", his/her position is "
                      + boardingCheck.PostionNumber
                      + ".");
        }
      }
    }
  }

  public class BoardingCheckAttribute : Attribute
  {
    public string ID { get; private set; }
    public string Name { get; private set; }
    public int FlightNumber { get; private set; }
    public int PostionNumber { get; private set; }
    public string Departure { get; private set; }
    public string Destination { get; private set; }

    public BoardingCheckAttribute(string id, string name, int flightNumber, int positionNumber, string departure, string destination)
    {
      this.ID = id;
      this.Name = name;
      this.FlightNumber = flightNumber;
      this.PostionNumber = positionNumber;
      this.Departure = departure;
      this.Destination = destination;
    }
  }
}
