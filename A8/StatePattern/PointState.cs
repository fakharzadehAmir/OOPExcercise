namespace StatePattern
{
    /// <summary>
    /// این وضعیت نشان دهنده حالتی است که نقطه زده شده
    /// این وضعیت شبیه وضعیت
    /// Accumulate
    /// است
    /// تنها فرقش این است که نقطه جدیدی نمی شود زد.
    /// تغییرات لازم را برای این کار بدهید.
    /// </summary>
    //🔴🔴🔴🔴 Base Class e in Class, AccumulateState hastesh ke baraye vaghtie ke
    //age ma momayez zadim varede in class beshe va be javabe ma ye point ya momayez
    // be onvane string ezafe kone va adad ashari ro be dorosti hesab kone 
    // (base) Accumulate (derived) point 
    public class PointState : AccumulateState
    {
        //🔴🔴🔴🔴 piade sazie tamae tabe haye in class shabihe Accumulate hastesh
        // tanha farghi kein class ba oon class bayad dashte bashe 
        //ine ke check kone ke ghablan ma . ya momayez zadim ya na 
        // age nazadim ezafe kone momayez ro be string this.Calc.Display
        //ezafe kone age zadim ham etefaghi nayofte va momayeze dgei ezafe nakone va bere soraghe 
        //charachtere baadi
        public PointState(Calculator calc) : base(calc)
        {
            if(!this.Calc.Display.Contains('.'))
                this.Calc.Display += ".";
        }
        // #1 لطفا
    }
}