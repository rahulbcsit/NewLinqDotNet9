using System;
using System.Linq;
using System.Collections.Generic;
					
public class Program
{
	public static void Main()
	{
	   
		 List<Student> students = [ new Student("Ram", "A"),
						 new Student("GhanShyam", "B"),
						 new Student("Hari", "C"),
						 new Student("Rita", "B"),
						 new Student("Sita", "C"),
					     new Student("Pushpa", "C")];
		
		var studentWithIndex = students.Index();
		
		foreach (var item in studentWithIndex)
		{
			
			Console.WriteLine($"Index is {item.Index} and  Valueis {item.Item.name}" );
		}
		
		var groupByStudent = students.GroupBy(x => x.score).Select(g =>  new KeyValuePair<string, List<string>>(g.Key, g.Select(x => x.name).ToList()));
		
		
		foreach (var (item, groups) in groupByStudent)
		{
			Console.WriteLine($"{item} --->");
			
			foreach (var g in groups)
			{
				Console.WriteLine(g);
			}
		}
		
		//countby
		
		var countedStudent = students.CountBy(x => x.score);
		
		foreach (var (score, count) in countedStudent)
		{
			Console.WriteLine($"Score {score} --> count {count}");
		}
		
		foreach (var item in countedStudent)
		{
			
			Console.WriteLine($"Score {item.Key} --> count {item.Value}");
		}
		
		//aggregate  by
		
		var aggregateStudent = students.AggregateBy(x => x.score,
												 seed :new List<string>(),
												 func : (group, student) => [..group, student.name]);
		
		Console.WriteLine ("Demoing AggregateBy");
		
		foreach (var (key, studentGroup) in aggregateStudent)
		{
			Console.WriteLine($"Student with Grade {key} --> {string.Join(" ,", studentGroup)}");
		}														  
		 
	}
	
	public record Student(string name, string score);
}