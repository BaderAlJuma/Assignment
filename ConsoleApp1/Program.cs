using System;
using System.IO;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			Teacher t1 = new Teacher(99, "Steve", "10/4");
			Teacher t2 = new Teacher(89, "Harvey", "10/2");
			t2.ID = 23;
			t2.ClassSection = "9/3";
			t1.Name = "Steve the Second";

			t2.UpdateData();
			t1.UpdateData();
			// You can use Teacher.DeleteFile() also to remove a text file for a given object
			Console.WriteLine("This program creates a text file for each Teacher object and stores it in the project " +
				"directory. To update the files, we use the UpdateData() method after changing the object variables.");
		}
	}
	class Teacher
	{
		string name;
		public string Path { get; set; }
		public int ID { get; set; }
		public string Name
		{
			get { return name; }
			set
			{
				if (value != this.name)
				{
					File.Delete(this.Path);
					this.name = value;
					this.Path = System.IO.Path.GetFullPath($@"..\..\..\{this.Name}.txt");
					File.WriteAllText(Path, "Name: " + value + Environment.NewLine
				+ "ID: " + this.ID + Environment.NewLine + "Class/Section: " + this.ClassSection);
					
				}
				this.name = value;
			}
		}
		public string ClassSection { get; set; }
		public Teacher(int id, string name, string classSection)
        {
			this.ID = id;
			this.name = name;
			this.ClassSection = classSection;
			this.Path = System.IO.Path.GetFullPath($@"..\..\..\{this.Name}.txt");
			

			File.WriteAllText(Path, "Name: "+this.Name + Environment.NewLine
				+ "ID: " + this.ID + Environment.NewLine + "Class/Section: " + this.ClassSection);
        }
        
		public void UpdateData()
        {
			File.WriteAllText(this.Path, "Name: " + this.Name + Environment.NewLine
				+ "ID: " + this.ID + Environment.NewLine + "Class/Section: " + this.ClassSection);
		}
		public void DeleteFile()
        {
			File.Delete(this.Path);
		}
	}
	
}