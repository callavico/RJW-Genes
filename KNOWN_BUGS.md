# Known Bugs 

Collection of Known Bugs and reasons for their origin. 

## I changed Parts of a pawn and my genes do not apply!

Issue: You had a pawn with "huge genitalia" and add a horse-cock with licentia or surgery. This new genitalia is not huge. 

Reason: The genes are applied when they are added. This is usually character-spawn. The genes change the attributes of the genitalia-hediff, and thus genitalia added after the genes are not affected. 

I think I will not gonna fix this. 
First of all, I think transplants wouldn't reasonably affected by genes. 
Second, for implementation I'd need to regularly check if every gene changed all relevant genitalia already, and do the same every x-ticks. 
This seems like a performance sink, so I will not gonna do it. 

## Pawn does not refresh empty Fertilin!

Issue: A pawn has 0 (or low) Fertilin, and a mood debuff. But they do not do anything about it. 

Reason: Pawns might go on a mental break when their fertilin is low to rape people. However, if your pawn is generally happy, they will not have a mental break. Then they run around with low fertilin. 

Workarounds / Solutions: Depending on your Gene-Setup, you might consider a cum-based diet. You can also tweak sex-settings for more sex need and hookups. Lastly, you can edit the xml to give higher mood penalties, which will lead to more mental breakdowns.

In general, I am happy to hear your feedback. If you have other ideas how to change this to be a bit tricky but not too punishing please let me know. 

## Fertilin does not go up after Sex!

Error: An Incubus or Succubus had sex with another pawn, but did not gain Fertilin. 

Things to consider: 

1. Please read descriptions of the respective genes - did you have "the right sex?" 
2. Check Hediffs of the fucked pawn - was it already drained? 
3. Did you fuck an animal? Check Settings for Fertilin-Multiplier
4. Did the pawns really *finish* ? In case they throw up or get drafted there is no gain. 

There also is a known mod-conflict with `rjw Animations patch` (See #18), so make sure you use up-to-date versions of everything.

## Seduce aborts on sex-start! 

Error: You have a succubus using seduce on a hostile pawn, they start sex but immediately abort. 

Things to Consider: 

1. Is your Succubus drafted? If not, they might have a flight-mode set and are scared of the enemy. 
2. Do you have mods changing combat AI? (CAI5000 or Combat Extended)

It seems that things changing Enemy Combat AI also affect this. One report was about CAI5000 and we also expect Combat Extended to be incompatible. 

## Random Vaginas for Goblins 

Error: Pawns have different genitalia than expected, e.g. if the "no vagina" gene is specified there are pawns with vaginas AND a penis. 

Possible causes: 

- The "Male Female Only Genes" from Steam 
- A Futa generated by RJW 

Solutions: 

I added my own Male/Female only genes, taking Genitalia and Order in Account. Yet there was no issue with this. 

Maybe you can also fix it by changing `<DisplayOrderInXenotype>` in the Male/Female only Genes of the Steamworkshop, to be higher than the ones about genitalia. This way, the gender should be changed before my genes fire. 


## Full-No-Genital-Genes get Genitals later 

*Update: Should be addressed with 1.1.1 and not appear anymore*

Error: I added all "no-XXX" genes but my pawn has genitalia on map!

Reason: If you go with Full-No-Genitals (No Penis, No Anus, No Breasts, No Vagina) then the pawn spawns without any Genitalia on the map, 
however then the RJW base-logic runs the sexualizer. 

**Workaround**: Have atleast 1 genitalia enabled with Genes, I recommend the anus. 

## Log Pops up for Xenotypes with Female/Male Only Gene 

*Update: Should not appear anymore after 1.1 when used with current rjw versions* 

Error: 

When using a Xenotype with the Female only gene, upon refresh it can open the log with the following (red) statement: 

```
[RJW]  ChangeSex error (PAWNNAME) faction (FACTION). Probably tried to change sex at world gen for royalty implant, skipping
UnityEngine.StackTraceUtility:ExtractStackTrace ()
Verse.Log:Error (string)
rjw.ModLog:Error (string)
rjw.GenderHelper:ChangeSex (Verse.Pawn,rjw.GenderHelper/Sex,rjw.GenderHelper/Sex)
rjw.GenderHelper:ChangeSex (Verse.Pawn,System.Action)
RJW_Genes.Gene_FemaleOnly:AdjustPawnToFemale ()
RJW_Genes.Gene_FemaleOnly:PostMake ()
RimWorld.GeneMaker:MakeGene (Verse.GeneDef,Verse.Pawn)
[... some more ...]
```

Reason: 

RJW covers some corner cases when the pawn is changed before creation. This seems a bit legacy and related to Royalty-Content.

Current Solution: 

Ignore this. The pawns seem to have the right sex and genitalia, I cannot "catch" the exception as it is only a Log Error. I would need to do harmony patching and ... that seems to be too much.  

Aimed Solution: 

Patch RJW ChangeSex upstream to skip for pawns with the two genes producing this.

## Error on Game Load:  Verse.GeneDef named rjw_genes_human_genitalia (wanter=genes)

Error: Issue #4, Game throws a warning on load that some Genes were not found. 

Reason: (Likely) because I removed some genes from Pre-Release to 1.0.0. Now some players have unknown definitions in their safe-files and Xenotype Defs. 
The removed Genes were the ones that performed default behaviour (e.g. normal breast size, normal penis size, ...)

Solution: Should be safe to ignore, when you get this on safe-load make a quick new safe. new safe should not throw the error. For Self-Made Xenotypes remove the Genes. 

Sorry about this one, I know removal can break things but hey you were playing with the Prerelease! 

## Insect Breeder does not fertilize

Update:

We changed behaviour in [1.0.1](https://github.com/vegapnk/RJW-Genes/releases/tag/1.0.1) and it seems to work now. Please tell us if you still encounter this. 

Error: 

A pawn with insect breeder fucks a pawn with unfertilized insect eggs, but the eggs stay unfertilized. 


Notes: 

So testing this is super hard. 

One thing - you need to have anal or vaginal sex for this to work. Any other sex type is currently not supported. 

For anything else, please help me gather information on this what you did and how things look. I reworked it once but I think it should work now. 
