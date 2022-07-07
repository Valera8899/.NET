using System;
using System.Collections.Generic;

namespace Lab4
{
    class Program
    {        
        static void Main()
        {   /*
        Розробити структуру організації армії в грі фентезі. Армія може складатися з 
        загонів ельфів, орків, мінотаврів, кентаврів, циклопів, драконів, гідр, лицарів. 
        Армія може містити як загони, так і одиночних воїнів, 
        загін може складатися з інших загонів і одиночних воїнів.                                   */

            Component Army = new Squad("Army"); // Army is root of the tree
            Component dragon_1 = new SingleWarrior("Dragon 1"); // SingleWarrior is a leaf
            Squad centaursSquad = new Squad("Centaurs squad 1");
            Squad centaursSquad2 = new Squad("Centaurs squad 2");
            Component elvesSquad = new Squad("Elves squad 1");

            Component elvesSubSquad = new Squad("Elves subsquad 1"); //squad is a subtree

            Army.Add(dragon_1);
            
            Army.Add(elvesSquad);
            elvesSquad.Add(new SingleWarrior("Elve 1"));

            elvesSubSquad.Add(new SingleWarrior("Elve 1.1"));
            elvesSubSquad.Add(new SingleWarrior("Elve 1.2"));
            elvesSquad.Add(elvesSubSquad);

            Army.Add(centaursSquad);

            centaursSquad.Add(new SingleWarrior("Centaur 1"));
            centaursSquad.Add(new SingleWarrior("Centaur 2"));
            centaursSquad.Add(new SingleWarrior("Centaur 3"));

            Army.Add(centaursSquad2);
            centaursSquad2.Add(new SingleWarrior("Centaur 1"));

            Component minotaur_1 = new SingleWarrior("Minotaur 1");
            Army.Add(minotaur_1);


            bool flag = true;
            while (flag)
            {
                Army.Print();
                Console.Write("\n");
                Console.Write("Input 1 to add new component, \n" +
                              "Input 2 to delete component, \n" +
                              "Exit the program — input -1: \n");

                string ans = Console.ReadLine();

                switch (ans)
                {
                    case "1":
                        Console.Write("Input name to add the component: ");
                        string name = Console.ReadLine();
                        Army.Add(new SingleWarrior(name));
                        Console.WriteLine();

                        break;

                    case "2":
                        Console.Write("Input number of component you want to delete: ");
                        int num = Convert.ToInt32(Console.ReadLine()) - 1;

                        try
                        {
                            Component componentToBeRemoved = Army.GetComponent(num);

                            if (componentToBeRemoved is SingleWarrior)
                            {
                                componentToBeRemoved = (SingleWarrior)componentToBeRemoved;
                                Army.Remove(componentToBeRemoved);
                            }
                            if (componentToBeRemoved is Squad)
                            {
                                componentToBeRemoved = (Squad)componentToBeRemoved;
                                Army.Remove(componentToBeRemoved);
                            }
                            Console.WriteLine();
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;


                    case "-1":
                        Console.WriteLine("Program stopped");
                        return;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Wrong input! Input correct value.");
                        Console.ResetColor();                        
                        break;
                }
                Console.Write("\n ");
            }

            


        }


        abstract class Component
        {
            protected string name;
            public Component(string name)
            {
                this.name = name;
            }

            public virtual void Print()
            { }

            public virtual void Add(Component c) { }
            public virtual void Remove(Component c) { }

            public virtual Component GetComponent(int i) 
            {
                return new SingleWarrior("examle warrior");
            }
        }

        class Squad : Component //"Squad" is a Composite
        {
            private List<Component> Components = new List<Component>();

            public Squad(string name)
            : base(name)
            { }
            public override void Add(Component c)
            {
                Components.Add(c);
            }

            public override void Remove(Component c)
            {
                Components.Remove(c);
            }

            public override Component GetComponent(int i)
            {
                return Components[i];
            }

            public override void Print()
            {
                Console.WriteLine(" " + name);
                Console.WriteLine("Components:"); //Components are Sub-squads  or single warriors
                for (int i = 0; i < Components.Count; i++)
                {
                    Console.Write(i+1 + ". "); Components[i].Print();
                }
            }

        }

        class SingleWarrior : Component //SingleWarrior is the leaf of the tree
        {
            public SingleWarrior(string name)
            : base(name)
            { }

            public override void Add(Component c)
            {
                throw new NotImplementedException();
            }
            public override void Remove(Component c)
            {
                throw new NotImplementedException();
            }
            
            public override Component GetComponent(int i)
            {
                throw new NotImplementedException();
            }
            
            public override void Print()
            {
                Console.ForegroundColor = ConsoleColor.Green; //display the leafs of the tree in green
                Console.WriteLine(name);
                Console.ResetColor(); 
            }
        }
    }
}




