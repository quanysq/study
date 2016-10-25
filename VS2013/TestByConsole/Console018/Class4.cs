using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using PostSharp.Aspects;
using PostSharp.Aspects.Advices;
using PostSharp.Extensibility;

namespace Console018
{
  /// <summary>
  /// AOP之PostSharp4-实现类INotifyPropertyChanged植入
  /// </summary>
  public class C4
  {
    public static void Execute()
    {
      Student stu = new Student();
      (stu as INotifyPropertyChanged).PropertyChanged += new PropertyChangedEventHandler(Program_PropertyChanged);
      stu.ID = 10;
      stu.Name = "wolf";
      stu.Sex = "Man";
      stu.ID = 2;
      Console.Read(); 
    }

    private static void Program_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      Console.WriteLine(string.Format("property {0} has changed", e.PropertyName));
    }
  }

  [Serializable]
  [IntroduceInterface(typeof(INotifyPropertyChanged), OverrideAction = InterfaceOverrideAction.Ignore)]
  public class INotifyPropertyChangedAttribute : InstanceLevelAspect, INotifyPropertyChanged
  {

    [OnLocationSetValueAdvice, MulticastPointcut(Targets = MulticastTargets.Property)]
    public void OnValueChanged(LocationInterceptionArgs args)
    {
      var current = args.GetCurrentValue();
      if ((args.Value != null && (!args.Value.Equals(current)))
          || (current != null && (!current.Equals(args.Value))))
      {
        args.ProceedSetValue();
        this.OnRaisePropertyChange(args.Location.Name);
      }
    }

    #region INotifyPropertyChanged 成员

    [IntroduceMember(IsVirtual = true, OverrideAction = MemberOverrideAction.Ignore)]
    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnRaisePropertyChange(string property)
    {
      if (PropertyChanged != null)
      {
        PropertyChanged.Invoke(this.Instance, new PropertyChangedEventArgs(property));
      }
    }
    #endregion
  }

  [INotifyPropertyChangedAttribute]
  public class Student
  {
    public string Name
    { get; set; }

    public string Sex
    { get; set; }

    public int ID
    { get; set; }
  }

  /*
   * 这里我们用到Postsharp的：
      IntroduceMember：向目标对象植入成员。
      IntroduceInterface：使得目标实现接口，参数接口类型。
      OnLocationSetValueAdvice：PostSharp的一种Advice Aspect。
   */
}
