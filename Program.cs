using System;
using System.Collections.Generic;

namespace ReizTechApplication
{
    class Branch
    {
        public List<Branch> branches;

        public Branch()
        {
            branches = new List<Branch>();
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            int answer = 0;
            do{
            Console.WriteLine("Please Select Problem Between 1 and 2: ");
            answer = int.Parse(Console.ReadLine());
            if(answer == 1){
                Problem1();
            }
            if(answer == 2){
                Problem2();
            }
            }while(answer == 1 || answer == 2);


        }
    public static void Problem1(){
            Console.WriteLine("Enter the hours (0-12):");
            int hours = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the minutes (0-59):");
            int minutes = int.Parse(Console.ReadLine());

            double angle = CalculateClockAngle(hours, minutes);

            Console.WriteLine($"The lesser angle between the hour and minute hands is: {angle} degrees");
    }
    public static void Problem2(){
            Branch root = new Branch(); //the first o

            root.branches.Add(new Branch()); // the left o
            root.branches.Add(new Branch()); // the right o

            root.branches[0].branches.Add(new Branch()); //the leftmost o

            root.branches[1].branches.Add(new Branch()); //3 right o
            root.branches[1].branches.Add(new Branch());
            root.branches[1].branches.Add(new Branch());

            root.branches[1].branches[0].branches.Add(new Branch()); //last left 0

            root.branches[1].branches[1].branches.Add(new Branch()); //the 2 middle o
            root.branches[1].branches[1].branches.Add(new Branch());

            root.branches[1].branches[1].branches[0].branches.Add(new Branch()); //last o

            // Calculate and display the depth
            int depth = CalculateDepth(root);
            Console.WriteLine($"The depth of the structure is: {depth}");

    }
    static int CalculateDepth(Branch node)
        {
            if (node == null)
            {
                return 0;
            }

            int maxDepth = 0;
            foreach (Branch child in node.branches)
            {
                int childDepth = CalculateDepth(child);
                if (childDepth > maxDepth)
                {
                    maxDepth = childDepth;
                }
            }

            return maxDepth + 1;
        }


        static double CalculateClockAngle(int hours, int minutes)
        {
            if (hours < 0 || hours > 12 || minutes < 0 || minutes > 59)
            {
                throw new ArgumentException("Invalid input. Please provide hours (0-12) and minutes (0-59).");
            }

            if (hours == 12)
            {
                hours = 0;
            }
            if (minutes == 60)
            {
                minutes = 0;
                hours += 1;
            }

            // Calculate the positions of the hour and minute hands
            double hourPosition = 0.5 * (hours * 60 + minutes);
            double minutePosition = 6 * minutes;

            // Calculate the angle between the two hands
            double angle = Math.Abs(hourPosition - minutePosition);

            // Return the lesser angle
            return Math.Min(360 - angle, angle);
        }
    }
}
