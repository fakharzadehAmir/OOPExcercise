namespace StatePattern
{
    /// <summary>
    /// ماشین حساب وقتی که جواب یک محاسبه
    /// را نشان میدهد وارد این وضعیت میشود
    /// </summary>
    
    //🔴🔴🔴🔴 vaghti ke be yek operator miresim
    //'*', '+', '-', '/', '^','='
    //return type AccumulateState baraye method haye operator va equal
    //new ComputeState hast be dalil inke baad az shenasaei yek operator vared yek class
    //marboot be mohasebe mishe ke hamoon ComputeState hast mishavad
    public class ComputeState : CalculatorState
    {
        public ComputeState(Calculator calc) : base(calc) {}
        //🔴🔴🔴🔴 agar baad az yek amalgar ya mosavi dobare ma mosavi bezanim error mide va be halate avalie bar migarde
        public override IState EnterEqual()
        {
            Calc.DisplayError("Syntax Error");
            return new ErrorState(this.Calc);
        }
        //🔴🔴🔴🔴baad az yek amalgar niaz hast ta ma yek string jadid baraye adad jadide khodemoon dorost konim
        //ke baadesh dobare ba Accumulation jam konim in do adad ro
        //Betore koli beine har do operaor ya equal
        //ye adad jadid hast ke bayad ba tavajh be amalgaremoon ye tasirir roo (double)Acumulation bezaran
        public override IState EnterNonZeroDigit(char c)
        {
            // #3 لطفا!
            this.Calc.Display = "";
            this.Calc.Display += c.ToString();
            return new AccumulateState(this.Calc);
        }
        //🔴🔴🔴🔴 baad az in ke charachter ghablimoon ke yek operator ya (=) 
        // baraye charactere baad varede in class mishe
        // hala age charachteri ke vared kardim 0 bud mesle vaghtie ke 
        //ma darim avalin charachter ro mizanim 
        //yani engar ke this.Calc.Display, "0" hastesh o ta vaghti ke yek raghame gheire sefr nadim,
        // hamoon sefr mimoone vase hamin return type in tabe ro az noe StartState gozashtim
        public override IState EnterZeroDigit()
        {
            // #4 لطفا
            this.Calc.Display = "0";
            return new StartState(this.Calc);
        }

        // #5 لطفا
        //🔴🔴🔴🔴 vaghti ke charachtere ghablie ma (ke ye operator ya '=' hast) ro mizanim
        //varede in class mishe va age charachter jadid e ma yek operator bashe Error mide Mashinhesab
        //yani age character ghabli masalan '+' bud va charachteri ke alan vared kardim
        //'-' bud mashin hesab error mide va varede class ErrorState mishe 
        public override IState EnterOperator(char c) => new ErrorState(this.Calc);
        //🔴🔴🔴🔴 in tabe mesle tabeye EnterPoint() Class StartState hastesh
        //baad az inke character ghablie ma yek operator ya '=' bud va charachtere jadidi ke ma mididm 
        // . bashe, bekhatere inke chizi ke ma ghable in ke momayez bezanim hichi nabud (masalan ragham bude)
        // besoorate default miad va yek 0 be gahble in momayez hesab mikone 
        //ta adade double ma ke gharer parse beshe too this.Accumulation,
        // error nade va kamel shenakhte shode bashe 
        public override IState EnterPoint()
        {
            Calc.Display = "0.";
            return new PointState(this.Calc);
        }

    }
}