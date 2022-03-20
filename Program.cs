// See https://aka.ms/new-console-template for more information

List<int> arr = new List<int> ();
arr.Add (1);
arr.Add (2); 
arr.Add (3);
arr.Insert(arr.Count + 1, 4);
Console.WriteLine(arr.ToString());
