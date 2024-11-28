# Rimbody_StatModule
Stat Module for Rimbody, a RimWorld Mod. This module integrates Rimbody’s Muscle Mass and Body Fat into pawns' stats.

## Features
 * Muscle is mostly beneficial to the stats, as most work needs muscle, and you don't gain muscle easily.
 * Fat is not so beneficial, but high fat will come in handy when you are starving, and having low fat can be deadly when you have no food.
 * Rimbody is also designed so that Fat helps pawns keep their muscle (bodyfat lowers muscle loss), so having a moderate, healthy amount of fat can be beneficial.

## Detailed Stats

### Vanilla
Stat | Relevant Info | Number
--- | --- | ---
Mass | Muscle, Fat | 40kg~110kg
Meat Amount | Muscle, Fat | x 0.5 ~ 1.375
Leather Amount | Muscle, Fat | x 0.5 ~ 1.375
Nutrition | Muscle, Fat | x 0.5 ~ 1.375 
Max Nutrition | Muscle, Fat | x 0.8 ~ 1.2
CarryingCapacity | Muscle | x 0.75 ~ 1.25
Arrest Success Chance | 2*Muscle, Fat | x 0.7 ~ 1.3
ComfyTemperatureMin | -Muscle, -2*Fat | -6 ~ +6
ComfyTemperatureMax | -Muscle, -2*Fat | -3 ~ 3
MoveSpeed | -Fat | x 0.85 ~ 1.15
Crawl Speed | -Fat |  x 0.85 ~ 1.15
Melee Damage Factor | Muscle | x 0.85 ~ 1.15
Stagger Duration | -2*Muscle, -Fat | x 0.85 ~ 1.15
Mining Speed | Muscle | x 0.85 ~ 1.15
Smoothing Speed | Muscle | x 0.85 ~ 1.15
Planting Speed | Muscle | x 0.85 ~ 1.15
Construction Speed | Muscle | x 0.85 ~ 1.15
Deepdrill Speed | Muscle | x 0.85 ~ 1.15
Malnutrition progress | -Fat | x0.5 ~ x1.2


### Combat Extended
Stat | Relevant Info | Number
--- | --- | ---
CarryWeight | Muscle | x 0.75 ~ 1.25
CarryBulk | Muscle | x 0.75 ~ 1.25
UnarmedDamage | Muscle | x 0.85 ~ 1.15
MeleeParryChance | Muscle |  x 0.85 ~ 1.15


### Stats not directly affected
Stat | Reason 
--- | ---
Dodge Chance | Affected by movement, which is already affected by muscle/fat
Hunting Stealth | Affected by movement, which is already affected by muscle/fat
Hunger Rate | Not a stat. Raising Max nutrition should emulate needing higher amount of food better.
