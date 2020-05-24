namespace Lab6
{
    
    [Couple(Pair = "Girl", Probability = 0.7, ChildType ="Girl")]
    [Couple(Pair = "PrettyGirl", Probability = 1, ChildType = "PrettyGirl")]
    [Couple(Pair = "SmartGirl", Probability = 0.5, ChildType ="Girl")]
    class Student : Human
    {
        public Student(string name) : base(name)
        {
        }
    }


}
