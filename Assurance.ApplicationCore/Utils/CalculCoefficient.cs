using Assurance.ApplicationCore.Entites;

namespace Assurance.ApplicationCore.Utils
{
    public static class CalculCoefficient
    {
        public static double CalculeCoefficient(AssuranceTardi assurance)
        {
            int ageClient = DateTime.Now.Year - assurance.DateDeNaissance.Year;
            double coefficient = 0.01;

            if (ageClient >= 20)
            {
                double trancheAge = (ageClient - 20) / 10;
                coefficient += trancheAge * 0.01 + 0.01;
            }

            // Client masculin
            if (assurance.Sexe == Sexe.masculin)
            {
                coefficient += 0.01;
            }

            // Client fumeur
            if (assurance.EstFumeur)
            {
                coefficient += 0.02;
            }

            if (assurance.EstDiabetique || assurance.EstHypertendu)
            {
                coefficient += 0.01;
            }

            if (assurance.PratiqueActivitePhysique && ageClient >= 30)
            {
                coefficient -= 0.01;
            }

            return coefficient;
        }
    }
}
