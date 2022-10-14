namespace StatePattern
{
    /// <summary>
    /// ماشین حساب وقتی به این حالت وارد میشود که خطایی رخ داده باشد
    /// از این حالت هر کلیدی که فشار داده شود به وضعیت اولیه باید برگردیم
    /// #2 لطفا!
    /// </summary>
    /*🔴🔴🔴🔴
    ErrorState vaghti ejra mishe ke
    Base Class in class CaculatorState hast ta vaghti ke mashinhesab dare kar mikone baste be sharayeti ke dare,
    varede yeki az class haye derivedesh mishe
    dar Error:  
    masalan vaghti dobar mosavi mizanim ya error haei mesle in,
    mashin hesab error mide va bar migarde be halate avalie
    mesle vaghti ke mashin hesab ro taze baz kardim va mikhaym avalin adad ro bezanim
    🔴🔴🔴🔴*/
    public class ErrorState : CalculatorState
    {
        public ErrorState(Calculator calc) : base(calc) { }
        public override IState EnterEqual() => new StartState(this.Calc);
        public override IState EnterNonZeroDigit(char c) => new StartState(this.Calc);
        public override IState EnterZeroDigit() => new StartState(this.Calc);
        public override IState EnterOperator(char c) => new StartState(this.Calc);
        public override IState EnterPoint() => new StartState(this.Calc);
    }
}