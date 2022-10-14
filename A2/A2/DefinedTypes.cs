using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace A2
{

public struct HelpStruct1{  decimal a,b,c,d,e,f,g,h;  };

public struct HelpStruct2{  TypeOfSize1024 a,b,c,d,e,f,g,h;  };

public struct HelpStruct3{  HelpStruct2 a,b;  };

public struct TypeOfSize5{  char a,b,c,d,e;  };

public struct TypeOfSize22{  TypeOfSize5 a,b,c,d;  char e,f;  };

public struct TypeOfSize125{  TypeOfSize22 a,b,c,d,e;  TypeOfSize5 f,g,h;  };

public struct TypeOfSize1024{  HelpStruct1 a,b,c,d,e,f,g,h;  };

public struct TypeOfSize32768{  HelpStruct2 a,b,c,d;  };



public struct TypeForMaxStackOfDepth10{  TypeOfSize32768 a,b,c; HelpStruct3 d;  };

public struct TypeForMaxStackOfDepth100{  HelpStruct2 a;  TypeOfSize1024 b,c,d,e,f;  };

public struct TypeForMaxStackOfDepth1000{  TypeOfSize1024 a;  HelpStruct1 b,c; };

public struct TypeForMaxStackOfDepth3000{  TypeOfSize125 a;  TypeOfSize22 b,c,d;  };



public class TypeWithMemoryOnHeap
{
    public void Allocate(){  ArrayForHeap = new TypeOfSize1024[4000];  }
    public void DeAllocate(){  ArrayForHeap = null;  }
    public TypeOfSize1024[] ArrayForHeap;
};



public struct StructOrClass1{ public int X; };

public class StructOrClass2{ public int X; };

public class StructOrClass3{ public StructOrClass2 X; };



public enum FutureHusbandType{  HasBigNose = 1  ,  IsShort = 1 << 1  ,  IsBald = 1 << 2  }

}