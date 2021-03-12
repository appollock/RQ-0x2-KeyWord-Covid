namespace GenericCovidObserver.Model
{
    public class CovidCell
    {
        public int MolecularMass { get; private set; }

        public CovidCell(int molecularMass)
        {
            MolecularMass = molecularMass;
        }
    }
}
