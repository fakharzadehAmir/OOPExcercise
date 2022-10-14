using System;

namespace StatePattern
{
    /// <summary>
    /// این کلاس بطور کامل پیاده سازی شده است و نیاز به تغییر ندارد.
    /// تنها تغییرات لازم کامنت های شماست 
    /// </summary>
    
    /*🔴🔴🔴🔴
    StartState vaghti ejra mishe ke 
    Base Class in class CaculatorState hast ta vaghti ke mashinhesab dare kar mikone baste be sharayeti ke dare,
    varede yeki az class haye derivedesh mishe
    dar StartState: 
    1: Baraye avalin bar mikhaym az calculatoremoon estefade konim
    2: Vaghti jayi az calculator be Error mikhore baraye inke be halate avalie bargarde,
    return type hameye method hash ro mishe new StartState(...) gozasht
    🔴🔴🔴🔴*/
    public class StartState : CalculatorState
    {
        public StartState(Calculator calc) : base(calc) { }
        public override IState EnterEqual() => 
            ProcessOperator(new ComputeState(this.Calc));
        //🔴🔴🔴🔴 vaghti raghame aval ro 0 mizanim engar ke hich raghmi vared nakardim
        //pas ta vaghti ke avalin raghamemoon ye chizi gheir az 0 bashe ma too hamin class mimoonim
        public override IState EnterZeroDigit()
        {
            this.Calc.Display = "0";
            return this;
        }
        //🔴🔴🔴🔴 agar onsore avalemoon adade gheire sefr bud alave bar inke oon ro be Clac.Displayemoon ezafe mikone
        //varede class AccumulateState ham mishe ke marboote be onsor haei ke baraye bare aval nemizanim va ghrare be javabe
        //akharemoon ezafe shan
        public override IState EnterNonZeroDigit(char c)
        {
            this.Calc.Display = c.ToString();
            return new AccumulateState(this.Calc);
        }

        public override IState EnterOperator(char c) => 
            ProcessOperator(new ComputeState(this.Calc), c);
        //🔴🔴🔴🔴 vaghti onsore aval ro momayez mizarim too har mashinhesabi be tore pishfarz "0." baad ragham haye baadi ro be
        //string display ke javabe aslimoon hast ro ezafe mikone va varede classe PointState mishe 
        //ke yek Derived Classe AccumulaeState hastesh
        public override IState EnterPoint()
        {
            this.Calc.Display = "0.";
            return new PointState(this.Calc);
        }
    }
}