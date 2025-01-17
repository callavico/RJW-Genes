﻿using System;
using System.Collections.Generic;
using Verse;
using RimWorld;
namespace RJW_Genes
{
    public class GeneUtility
    {
        
        //Split function so I can offsetlifeforce from gene without needing to look for the gene agian (for the constant drain tick)
        public static Gene_LifeForce GetLifeForceGene(Pawn pawn)
        {
            Pawn_GeneTracker genes = pawn.genes;
            Gene_LifeForce gene_LifeForce = genes.GetFirstGeneOfType<Gene_LifeForce>();
            return gene_LifeForce;
        }

        public static void OffsetLifeForce(IGeneResourceDrain drain, float offset)
        {                
            float old_value = drain.Resource.Value;
            drain.Resource.Value += offset;
            PostOffSetLifeForce(drain, old_value);     
        }

        public static void PostOffSetLifeForce(IGeneResourceDrain drain, float old_value)
        {
            if (old_value > 0.2f && drain.Resource.Value <= 0.2f)
            {                
                //TODO: Mood debuff
            }
            else if (old_value > 0f && drain.Resource.Value <= 0f)
            {
                Pawn pawn = drain.Pawn;
                if (!drain.Pawn.health.hediffSet.HasHediff(HediffDefOf.rjw_genes_fertilin_craving))
                {
                    drain.Pawn.health.AddHediff(HediffDefOf.rjw_genes_fertilin_craving);
                }
            }
        }


        public static bool HasLowLifeForce(Pawn pawn)
        {
            if (HasLifeForce(pawn))
            {
                Gene_LifeForce gene = pawn.genes.GetFirstGeneOfType<Gene_LifeForce>(); 
                if (gene == null || !gene.Active)
                    return false;
                if (gene.Resource.Value < gene.targetValue)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool HasCriticalLifeForce(Pawn pawn)
        {
            if (HasLifeForce(pawn))
            {
                Gene_LifeForce gene = pawn.genes.GetFirstGeneOfType<Gene_LifeForce>();
                if (gene == null || !gene.Active)
                    return false;
                if (gene.Resource.Value < gene.MinLevelForAlert)
                {
                    return true;
                }
            }
            return false;
        }

        public static float MaxEggSizeMul(Pawn pawn)
        {
            float MaxEggSize = 1;
            if (IsInsectIncubator(pawn))
            {
                MaxEggSize *= 2;
            }
            return MaxEggSize;
        }
        public static List<Gene_GenitaliaResizingGene> GetGenitaliaResizingGenes(Pawn pawn)
        {
            var ResizingGenes = new List<Gene_GenitaliaResizingGene>();

            // Error Handling: Issue with Pawn or Genes return empty.
            if (pawn == null || pawn.genes == null)
                return ResizingGenes;

            foreach (Gene gene in pawn.genes.GenesListForReading)
                if (gene is Gene_GenitaliaResizingGene resizing_gene)
                    ResizingGenes.Add(resizing_gene);

            return ResizingGenes;
        }

        /// <summary>
        /// Unified small check for a pawn if it has a specified Gene. 
        /// Handles some errors and returns false as default.
        /// </summary>
        /// <param name="pawn">The pawn for which to look up a gene.</param>
        /// <param name="genedef">The gene to look up.</param>
        /// <returns></returns>
        public static bool HasGeneNullCheck(Pawn pawn, GeneDef genedef)
        {
            if (pawn.genes == null)
            {
                return false;
            }
            return pawn.genes.HasGene(genedef);
        }

        public static bool HasLifeForce(Pawn pawn) { return HasGeneNullCheck(pawn, GeneDefOf.rjw_genes_lifeforce); }
        public static bool IsMechbreeder(Pawn pawn) { return HasGeneNullCheck(pawn, GeneDefOf.rjw_genes_mechbreeder); }
        public static bool IsInsectIncubator(Pawn pawn) { return HasGeneNullCheck(pawn, GeneDefOf.rjw_genes_insectincubator); }
        public static bool IsYouthFountain(Pawn pawn) { return HasGeneNullCheck(pawn, GeneDefOf.rjw_genes_youth_fountain); }
        public static bool IsAgeDrainer(Pawn pawn) { return HasGeneNullCheck(pawn, GeneDefOf.rjw_genes_sex_age_drain); }
        public static bool IsInsectBreeder(Pawn pawn) { return HasGeneNullCheck(pawn, GeneDefOf.rjw_genes_insectbreeder); }
        public static bool IsElastic(Pawn pawn) { return HasGeneNullCheck(pawn, GeneDefOf.rjw_genes_elasticity); }
        public static bool IsCumflationImmune(Pawn pawn) { return HasGeneNullCheck(pawn, GeneDefOf.rjw_genes_cumflation_immunity); }
        public static bool IsGenerousDonor(Pawn pawn) { return HasGeneNullCheck(pawn, GeneDefOf.rjw_genes_generous_donor); }
        public static bool IsPussyHealer(Pawn pawn) { return HasGeneNullCheck(pawn, GeneDefOf.rjw_genes_pussyhealing); }
        public static bool IsUnbreakable(Pawn pawn) { return HasGeneNullCheck(pawn, GeneDefOf.rjw_genes_unbreakable); }
        public static bool HasParalysingKiss(Pawn pawn) { return HasGeneNullCheck(pawn, GeneDefOf.rjw_genes_paralysingkiss); }
        public static bool HasSeduce(Pawn pawn) { return HasGeneNullCheck(pawn, GeneDefOf.rjw_genes_seduce); }
        public static bool IsSexualDrainer(Pawn pawn) { return HasGeneNullCheck(pawn, GeneDefOf.rjw_genes_drainer); }
        public static bool IsCumEater(Pawn pawn) { return HasGeneNullCheck(pawn, GeneDefOf.rjw_genes_cum_eater); }

    }
}

/*
Exception in Verse.AI.ThinkNode_Priority TryIssueJobPackage: System.NullReferenceException: Object reference not set to an instance of an object
  at RJW_Genes.GeneUtility.HasLowLifeForce (Verse.Pawn pawn) [0x00014] in < 881b7541af8144a78a14c9dad08e43c7 >:0
  at RJW_Genes.ThinkNode_ConditionalLowLifeForce.Satisfied(Verse.Pawn p) [0x00000] in < 881b7541af8144a78a14c9dad08e43c7 >:0
  at Verse.AI.ThinkNode_Conditional.TryIssueJobPackage(Verse.Pawn pawn, Verse.AI.JobIssueParams jobParams) [0x00000] in < 38562b1a2ab64eacb931fb5df05ca994 >:0
  at Verse.AI.ThinkNode_Priority.TryIssueJobPackage(Verse.Pawn pawn, Verse.AI.JobIssueParams jobParams) [0x00022] in < 38562b1a2ab64eacb931fb5df05ca994 >:0
UnityEngine.StackTraceUtility:ExtractStackTrace()
Verse.Log:Error(string)
Verse.AI.ThinkNode_Priority:TryIssueJobPackage(Verse.Pawn, Verse.AI.JobIssueParams)
Verse.AI.ThinkNode_SubtreesByTag:TryIssueJobPackage(Verse.Pawn, Verse.AI.JobIssueParams)
Verse.AI.ThinkNode_Priority:TryIssueJobPackage(Verse.Pawn, Verse.AI.JobIssueParams)
Verse.AI.Pawn_JobTracker:DetermineNextJob(Verse.ThinkTreeDef &)
Verse.AI.Pawn_JobTracker:TryFindAndStartJob()
Verse.AI.Pawn_JobTracker:EndCurrentJob(Verse.AI.JobCondition, bool, bool)
Verse.AI.Pawn_JobTracker:JobTrackerTick()
Verse.Pawn:Tick()
Verse.TickList:Tick()
(wrapper dynamic - method) Verse.TickManager:Verse.TickManager.DoSingleTick_Patch2(Verse.TickManager)
Verse.TickManager:TickManagerUpdate()
Verse.Game:UpdatePlay()
Verse.Root_Play:Update()
*/