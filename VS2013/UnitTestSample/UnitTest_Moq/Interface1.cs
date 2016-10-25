using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest_Moq
{
  public interface IUnitTestForMoq
  {
    string SayHellow();
    int GetCount();
  }

  public class Person
  {
    public string ID { get; set; }

    public string Name { get; set; }

    public int Age { get; set; }

    public string Job { get; set; }
  }

  public interface IPersonProvider
  {

    Person GetPersonById(string id);

    bool RemovePerson(string id);

  }
}
