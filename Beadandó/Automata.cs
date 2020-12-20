using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Beadandó
{
    class Automata
    {
        public static string[,] matrix = new string[12,7];
        public Stack stack;
        public string ruleNumber = "";
        List<string> numbers = new List<string>();
        public string input;
        public static bool check = false;
      
        public string simple(string i)
        {
            string expressionstring = Regex.Replace(i, "([0-9]+)", "i");
            return expressionstring;
        }
        public Automata(string inp)
        {

            Console.WriteLine("Eredeti input : {0}", inp);
            if (!inp.Contains('#'))
            {
                this.input = $"{simple(inp)}#";
                Console.WriteLine("Az egyszerűsített input: {0}", this.input);
            }
            else
            {
                this.input= $"{simple(inp)}";
                Console.WriteLine("Az egyszerűsített input: {0}", this.input);

            }


        }



        public void OpenFileToRead(string path)
        {
            StreamReader sr = new StreamReader(File.OpenRead(path));
            string[] columnsInMatrix = new string[matrix.GetLongLength(1)];
            string s = "";


            int index = 0;
            while (!sr.EndOfStream)
            {
                s += sr.ReadLine();
                for (int x = 0; x < columnsInMatrix.Length; x++)
                {
                    columnsInMatrix[x] = s.Split('|')[x];
                }

                for (int y = 0; y < columnsInMatrix.Length; y++)
                {
                    matrix[index, y] = columnsInMatrix[y];
                }

                s = "";
                index++;
            }

            for (int x = 0; x < matrix.GetLength(0); x++)
            {

                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    Console.Write("{0} |", matrix[x, y]);
                }
                Console.WriteLine();
            }
        }

        public bool rules(string matrixElem)
        {

            if (matrixElem.Length == 0)
            {
                Console.WriteLine("Hibás kifejezés.");
                check = true;
                return true;
            }

            if (matrixElem.Trim() == "elfogad")
            {
             
                Console.WriteLine("Az elemzés lefutott.");
                check = true;
                return true;
            }
           
            if (matrixElem.Trim() == "pop")
            {
              
                this.input = input.Substring(1);
                 
                return false;
            }

            if (matrixElem.Contains('('))
            {
                string sr = matrixElem.Substring(1).Split(',')[0];
                for (int j = sr.Length - 1; j >= 0; j--)
                {
                    if (sr[j].Equals('e'))
                    {
                        continue;
                    }
                    stack.Push(sr[j].ToString());
                }
            }

            if (matrixElem.Contains(')'))
            {

                ruleNumber += matrixElem.Substring(0, matrixElem.Length - 1).Split(',')[1];
                numbers.Add(ruleNumber);
                ruleNumber = "";
            }
            return false;
        }

        public void process()
        {
            string temp;

            stack = new Stack();
            stack.Push("#");
            stack.Push("E");

            do
            {
                temp = stack.Pop().ToString();
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    if (input[0].ToString() == matrix[0, y])
                    {
                        for (int x = 0; x < matrix.GetLength(0); x++)
                        {
                            if (temp == matrix[x, 0])
                            {
                                if (temp == "#")
                                {
                                    stack.Push('#');
                                    check = rules(matrix[x, y]);
                                }
                                else {

                                    check = rules(matrix[x, y]);
                                    Console.WriteLine("({0},\t {1},\t {2}\t)", input, aktStackList(stack), aktNumbersList(numbers));
                                }

                            }

                        }
                    }
                }
            } while (!check);
        }
        public string aktStackList(Stack stack)
        {
            string elements = "";
            string[] stackBlock = new string[stack.Count];
           
           stack.CopyTo(stackBlock, 0);
            
           

            for (int i = 0; i < stackBlock.Length; i++)
            {
                elements += stackBlock[i];
            }

            return elements;
        }
        public string aktNumbersList(List<string> numbers )
        {
            string elements = "";
            for (int i = 0; i < numbers.Count; i++)
            {
                elements += numbers[i];
            }

            return elements;
        }
    }
}
