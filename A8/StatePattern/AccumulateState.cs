using static System.Console;
//🔴🔴🔴🔴 in class baray vaghtie ke avalin ragham ro zadim va baraye kilid haye baadi
//varede in class mishe 
//1: age adade aval gheire sefr bud varede in class mishe 
//2: age momayez bud varede derived class in class mishe yani PointState
//hala age ma har kilidi ro bezanim motabegh ba charachter hamoon 
//yeki az tabe haye in class ejra mishe ke baraye harkodoom joda tarif mikonam
namespace StatePattern
{
    public class AccumulateState : CalculatorState
    {
        public AccumulateState(Calculator calc) : base(calc) { }

        // #7 لطفا
        //🔴🔴🔴🔴 age karbar '=' bezane varede in tane EnterEqual mishe 
        //ke baad az hesab kardan meghdar jadid va tabdilesh be string
        //va in this.Calc(ke yek object az Class Calculator hast ) ro be Constructore e 
        //ComputeState mide ke makhsoose operator ha bud 
        public override IState EnterEqual()
        {
            this.Calc.Evalute();
            this.Calc.Display = this.Calc.Accumulation.ToString();
            return new ComputeState(this.Calc);
        }
        //🔴🔴🔴🔴 agar raghami gheir az raghame aval ro sefr bezanim
        //be hamoon tedad be this.Calc.Display '0' ezafe mishe bar axe StartState
        public override IState EnterZeroDigit() => EnterNonZeroDigit('0');
        //🔴🔴🔴🔴 mesle EnterZeroDigit() in class charachter ha ke adad hastand string mishan
        //va baraye onsore baadi ke vared mikonim dobare varede hamin class mishan 
        //pas agar raghame gheire avali ke mizanim harchi bud baraye charachtere baadi ham varede hamin class mishe
        //va check mikone ke '=' hast ya yek operator ya adade jadidie
        public override IState EnterNonZeroDigit(char c)
        {
            // #8 لطفا!
            this.Calc.Display += c.ToString();
            return this;
        }
        //🔴🔴🔴🔴 baad az inke charachtere ghablimoon yek adad bud
        //(charactere ghabli avalin charachteri nist ke miaznim)
        //in charcter jadidi ke mizanim age yek operator gheir az mosavi bud 
        //mesle '^', '*', '+', '-', '/' miad va ta inja Accumulation ke yek double hast va
        //gharare javabe ma toosh rikhte beshe ro hesab mikone va choonke yek operator hast va gharere
        //javab ro tainja hesab kone varede class ComputeState mishe
        // #9 لطفا!
        public override IState EnterOperator(char c) 
        {
            this.Calc.Evalute();
            return new ComputeState(this.Calc);
        }
        //🔴🔴🔴🔴 vaghti ke character ghablie ma ye adad bud (charachtere ghabli avalin raghamin nist ke ma mizanim)
        // va in charachteri ke alan gharare bezanim Point(.) ya momayeze varede in tabe mishe va be class 
        //PointState mire ke makhsoose vaghtie ke ma . mizanim (PointState ye Derived Class az AccumulateState hastesh
        // choon piade sazie hameye tabe hash mesle hamin classe faghat toye constructor ye taghiri mishe dad ke 
        //too hamoon class tozih midam)
        public override IState EnterPoint() =>
            // #10 لطفا!
            new PointState(this.Calc);
    }
}