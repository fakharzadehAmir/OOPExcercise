using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace A7
{
    public class ExceptionHandler
    {
        public string ErrorMsg { get; set; }
        public readonly bool DoNotThrow;
        private string _Input;

        public string Input
        {
            get
            {
                try
                {
                    if (_Input.Length < 50)
                        return _Input;
                }
                catch
                {
                    if (!DoNotThrow)
                        throw;
                    ErrorMsg = "Caught exception in GetMethod";
                }
                return null;
            }
            set
            {
                try
                {
                    if (value.Length < 50)
                        _Input = value;
                }
                catch
                {
                    if (!DoNotThrow)
                        throw;
                    ErrorMsg = "Caught exception in SetMethod";
                }
            }
        }


        public ExceptionHandler(
            string input,
            bool causeExceptionInConstructor,
            bool doNotThrow=false)
        {
            DoNotThrow = doNotThrow;
            this._Input = input;
            try
            {
                if (causeExceptionInConstructor)
                {
                    string test = null;
                    if (test.Length > 0)
                        Console.WriteLine("test");
                }
            }
            catch
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = "Caught exception in constructor";
            }
        }

        public void OverflowExceptionMethod()
        {
            #region TODO
            long n = (long)(int.Parse(this.Input))+100;
            checked
            {
                try
                {
                    int nCompare = (int) n;
                }
                catch(OverflowException oe)
                {
                    if(!DoNotThrow)
                        throw;
                    ErrorMsg = $"Caught exception {oe.GetType()}";
                }
            }
            #endregion
        }

        public void FormatExceptionMethod()
        {
            try
            {
                int i = int.Parse(Input);
            }
            catch(FormatException e)
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {e.GetType()}";
            }
        }

        public void FileNotFoundExceptionMethod()
        {
            #region TODO
            try
            {
                using(StreamReader sr = new StreamReader($@"..\..\..\File{this.Input}.txt"))
                    sr.ReadToEnd();
            }
            catch(FileNotFoundException fnfe)
            {
                if(!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {fnfe.GetType()}";
            }
            #endregion
        }

        public void IndexOutOfRangeExceptionMethod()
        {
            #region TODO
            try
            {
                if(int.Parse(this.Input)!=0)
                {
                    int[] newArray = new int[]{1,2,3,4,5};
                    for(int i = 0  ; i < newArray.Length+1 ; i++)
                        newArray[i]++;
                }
            }
            catch(IndexOutOfRangeException iore)
            {
                if(!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {iore.GetType()}";
            }
            #endregion
        }

        public void OutOfMemoryExceptionMethod()
        {
            #region TODO
            try
            {
                int size = int.Parse(this.Input);
                int[] newArray = new int[size];
            }
            catch(OutOfMemoryException oome)
            {
                if(!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {oome.GetType()}";
            }
            #endregion
        }

        public void MultiExceptionMethod()
        {
            #region TODO
            try
            {
                int size = int.Parse(this.Input);
                int[] newArray = new int[size];
                if(int.Parse(this.Input)!=0)
                {
                    for(int i = 0  ; i < newArray.Length+1 ; i++)
                        newArray[i]++;
                }
            }
            catch(Exception e) when(e is IndexOutOfRangeException || e is OutOfMemoryException)
            {
                if(!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {e.GetType()}";
            }
            #endregion
        }

        public static void ThrowIfOdd(int n)
        {
            #region TODO
            if(n%2==1)
                throw new InvalidDataException("Number is odd");
            #endregion
        }

        public string FinallyBlockStringOut;

        public void FinallyBlockMethod(string s)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter swr = new StringWriter(sb);
            try
            {
                #region TODO
                swr.Write("InTryBlock:");
                if(s=="ugly")
                    return;
                swr.Write($"{s}:{s.Length}:DoneWriting");
                #endregion
            }
            catch (NullReferenceException nre)
            {
                #region TODO
                swr.Write($":{nre.Message}");
                if(!DoNotThrow)
                    throw;
                #endregion
            }
            finally
            {
                swr.Write(":InFinallyBlock");
                swr.Dispose();
                FinallyBlockStringOut = sb.ToString();
            }
            FinallyBlockStringOut += ":EndOfMethod";
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void NestedMethods() =>
            #region TODO
            MethodA();
            #endregion
        #region TODO
        private static void MethodA() => MethodB();
        private static void MethodB() => MethodC();
        private static void MethodC() => MethodD();
        private static void MethodD() =>
            throw new NotImplementedException();
        #endregion
    }
}
