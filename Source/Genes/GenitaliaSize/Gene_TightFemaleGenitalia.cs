﻿using Verse;
using rjw;
using System;

namespace RJW_Genes
{
    public class Gene_TightFemaleGenitalia : Gene
    {

        public override void PostMake()
        {
            base.PostMake();
            if (GenitaliaUtility.PawnStillNeedsGenitalia(pawn))
                Sexualizer.sexualize_pawn(pawn);

            SizeAdjuster.AdjustAllVaginaSizes(pawn, 0.0f, 0.5f);
        }
        
        public override void PostAdd()
        {
            base.PostAdd();
            SizeAdjuster.AdjustAllVaginaSizes(pawn, 0.0f, 0.5f);
        }

    }
}