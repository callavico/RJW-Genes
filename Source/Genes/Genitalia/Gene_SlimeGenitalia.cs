﻿using Verse;
using rjw;

namespace RJW_Genes
{
    public class Gene_SlimeGenitalia : Gene
    {
        public override void PostMake()
        {
            base.PostMake();
            if (GenitaliaUtility.PawnStillNeedsGenitalia(pawn))
                Sexualizer.sexualize_pawn(pawn);

            GenitaliaChanger.ChangeGenitalia(this.pawn,Genital_Helper.slime_penis,Genital_Helper.slime_vagina,Genital_Helper.slime_anus);
        }

        public override void PostAdd()
        {
            base.PostMake();
            GenitaliaChanger.ChangeGenitalia(this.pawn, Genital_Helper.slime_penis, Genital_Helper.slime_vagina, Genital_Helper.slime_anus);
        }
    }

}