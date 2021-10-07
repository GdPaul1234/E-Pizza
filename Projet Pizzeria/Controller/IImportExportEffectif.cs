namespace Projet_Pizzeria.Model
{
    public interface IImportExportEffectif
    {
        void ImportClient();

        void ExportClient();

        void ImportLivreur();

        void ExportLivreur();

        void ImportCommis();

        void ExportCommis();
    }
}