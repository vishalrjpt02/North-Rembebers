using System;

class MainClass : CampusMind{

  public static void Main (string[] args) {

    Console.WriteLine("Enter the size of your team");
    int len=Convert.ToInt32(Console.ReadLine());
    CampusMind []students=new CampusMind[len];
    bool flag=true;
    while(flag){
      Console.WriteLine("Mark your choice below..\n1.Add Student.. \n2. Display all team data...\n3.Sort on name\n4.sort even place\n5.search for position\n6.Exit");
      string choice=Console.ReadLine();
      switch(choice){
        case "1":
            AddStudent(students);
            break;
        case "2":
            DisplayData(students);
            break;
        case "3":
             students=sortOnname(students);
             DisplayData(students);
             break;
        case "4":
            students=sortOnEven(students);
            DisplayData(students);
            break;
        case "5":
            Console.WriteLine("Enter the key to be search for");
            int key= Convert.ToInt32(Console.ReadLine());
            searchForPos(students,key);
            break;
        case "6":
            Console.WriteLine("Thank you");
            flag=false;
            break;
        default:
            Console.WriteLine("Invalid input");
            break;
      }
    }
  }


  public static void AddStudent(CampusMind[] student){
    for(int i=0;i<student.Length;i++){
      CampusMind temp=new CampusMind();
        Console.WriteLine("Enter the name of student");
        temp.name =Console.ReadLine();
        temp.id = i+1;
        student[i]=temp;
    }
    
    DisplayData(student);
  }

  
  public static void DisplayData(CampusMind[] student)
  {
      Console.WriteLine( "ID   Student NAME ");
      for(int i=0;i<student.Length;i++){
        Console.WriteLine( student[i].id +"   "+ student[i].name);
      }
  }

  public static CampusMind[] sortOnname(CampusMind []student){
    for(int i=0;i<student.Length;i++){
      for(int j=i;j<student.Length;j++){
        if(student[i].name==student[j].name)
        {
          CampusMind temp=student[i];
          student[i].name=student[j].name;
          student[j]=temp;
        }
      }
    }
    return student;
  }

  public static CampusMind[] sortOnEven(CampusMind []student){
   for(int i=0;i<student.Length;i++){
      for(int j=i;j<student.Length;j++){
        if(student[i].id.CompareTo(student[j].id)>0 && (i%2==0 && j%2==0)){
          CampusMind temp=student[i];
          student[i]=student[j];
          student[j]=temp;
        }
      }
    }
    return student; 
  }


  public static void searchForPos(CampusMind []student,int key){
    for(int i=0;i<student.Length;i++){
      if(key==student[i].id){
        Console.WriteLine("Index of the student in array is "+i+" and Name is"+student[i].name);
      }
    }
  }

}


public class CampusMind
{
   public int id;
   public string name;
  //CampusMind []Students = new CampueMind[10];

}