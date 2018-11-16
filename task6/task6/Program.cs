using System;
using System.Collections.Generic;

namespace task6
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgramConverter progConv1 = new ProgramConverter();
            ProgramConverter progConv2 = new ProgramConverter();

            ProgramHelper progHelp1 = new ProgramHelper();
            ProgramHelper progHelp2 = new ProgramHelper();

            List<ProgramConverter> progConvArray = new List<ProgramConverter>();
            progConvArray.Add(progConv1);
            progConvArray.Add(progHelp1);
            progConvArray.Add(progConv2);
            progConvArray.Add(progHelp2);

            foreach (var obj in progConvArray)
            {
                if (obj is ICodeChecker)
                {
                    //obj.CheckCodeSyntax("smth();", "C#");
                    obj.ConvertToCSharp("sub end.");
                }
                else
                {
                    obj.ConvertToCSharp("sub end.");
                    obj.ConvertToVB("smth();");
                }
            }
        }
    }
    interface IConvertible
    {
        string ConvertToCSharp(string code);
        string ConvertToVB(string code);
    }
    interface ICodeChecker
    {
        bool CheckCodeSyntax(string code, string lang);
    }
    class ProgramHelper : ProgramConverter, ICodeChecker
    {
        public bool CheckCodeSyntax(string code, string lang)
        {
            Random rand = new Random();
            if (rand.NextDouble() == 0) return true;
            else return false;
        }
    }
    class ProgramConverter : IConvertible
    {
        public string ConvertToCSharp(string code) { return "Converted to C#"; }
        public string ConvertToVB(string code) { return "Converted to VB"; }
    }
}
