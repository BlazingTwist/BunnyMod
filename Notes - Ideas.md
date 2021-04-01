﻿# Additions

## Classes

### Drug Dealer

- Trait: Pusher
  - You can interact with most NPCs to attempt to sell them Sugar.
  - Cops who witness a dealing attempt will go Hostile. 
  - Anyone who refuses your sale will become Annoyed. 
  - Upper Crusters will call the cops immediately.
  - On a successful sale, The buyer has a chance to become Hooked. 
    - Jonesing 
      - After a certain interval of withdrawal, Hooked NPCs will gain the Jonesing status. They'll seek you out in the level and beg you for Sugar. 
      - If you go too long without selling to them, they'll go hostile, but selling them other types of drugs will keep them at bay for a while. When Jonesing, they will freely give you keys and safe combos if you ask. 
      - Jonesing NPCs may also attack other drug dealers, doctors, or scientists if they can't track you down.
- Trait: Death to Snitches - Cops will ignore your Pusher attempts. You may attempt to sell to them, but failure will turn them hostile.
- BQ: Slingin' Dope - NPCs with enough money to buy one of your drugs will have an arrow above their head when the Big Quest is open. You need to sell to a certain number of NPCs.
- Item: Sugar Processor (6) - Similar to Bomb Processor. 

### Priest
- Trait: Undead Bane - All Vampires, Zombies & Ghosts are hostile on sight.
- Trait: Sermon - Activate an Altar to randomly improve relations with NPCs within earshot. Chance of them giving you Tithes.
- BQ: Get Thee Behind Me! - Kill all Zombies and Vampires on the map. Vampires are armed and travel in teams.
- Item: Holy Symbol (4) - When in your inventory, all Undead NPCs slowly take damage when they're near you. They are more likely to flee during combat.
- Item: Holy Water Flask (2) - Thrown weapon that gives a Poison condition to Zombies & Werewolves. Can also be combined with a Water Gun, Air Vent, or Water Filter.

### Worker
- Trait: One Happy Tamper - Tamper without angering Owner (Or just extend this into Clumsiness Forgiven)

### Trapper
- Trait: Cheeky Trappy - All hidden traps are visible to you. NPCs will no longer path around traps that you place.
- Trait: ____ - Increase trap damage.
- Trait: Trapper Keeper - You can Interact with traps to add them to your inventory (Bear Traps, Land Mines). 100% chance to deactivate Door Detonators.
- Item: Fire Mine (4) - Behaves like a Molotov when it explodes.
- Item: Gas Trap Kit (6) - Combine with a Syringe to make a Gas Trap that you can place like a Land Mine.

### NPCs
- Artist
- Farmer
- Detective
- Junkie
- Reporter
- Security Guard
- Tourist
  - Travels in groups, occasional goon
  - Behaves like Upper Cruster

## Items

- Mini Turret (3) - It's a Turret.
- Beer Can (1) - Generated when a Beer is consumed, or found on its own in trash cans. Thrown weapon, does minimal damage for funsies. Like a more useless Rock.
- Fancy Hat (3) - Increased chances for persuasion. Maybe a Fedora, because I want you to cringe.
- Fear Syringe (1) - (Maybe not possible since there's no fear for player characters)
- Lunchbox (1) - Thrown item. Deals rock-level damage, drops a food item on impact.
- Oil Bottle (1) - Thrown weapon that creates a splash of oil upon impact.
- Riot Armor (3) - Resists bullets and melee damage.
- Riot Helmet (2) - Just another aesthetic option.
- Spear (1) - Thrusting weapon, longest melee reach. Deals damage equal to Knife.
- Teleportation Trap (2) - Floor trap.
- Toxic Slime Capsule (1) - Thrown item. Inflicts poison and leaves a Goop Splash.
- Water Gun - Extended to combine with Oil Can, so you can shoot Oil.
- Whiskey Bottle (1) - Generated when Whiskey is consumed, or found on its own in trash cans. Thrown weapon, does minimal damage for funsies. Like a more useless Rock.
- Magic items:
	- Mana Crystals (decay slowly but unpredictably, increase recharge speed)
	- Miscast Crystals (Rare, but absorb a miscast and shatter)
	- Ultrachungus Crystals (Temporarily boost your ability to obscene levels)
- BackPack - +inventory slots
- Body Spray: Anti-cologne, basically gives ideological clash to whoever uses it. (This would be cool in assassin quests if you could apply it to your target.)

## Mutators
- Zoom Levels
	- https://discord.com/channels/187414758536773632/433748059172896769/815314079408980000
- All Walls Are Wood
- All Walls Are Steel
- Major disaster behavior changes
  - Cops don't enforce property damage laws
  - Some NPCs will join your party for safety
- Riot
  - Add Arsonists to spawns
  - Rioters shouldn't ignore cops
   	- You can change this in LevelFeelings.Riot2, cops aren't mentioned there
- Mafia spawn on all levels
  - Would be extremely easy, just set LevelData.levelFeatures.Contains("Mafia") to true
- District-related spawns
  - LevelEditor.CreateLevelFeatureList
	

## Objects
- Cash Register
  - A tough locked object containing money
  - Unlocking 
    - Computer
    - Hack
    - Lockpicked
    - Crowbar
  - Easier than a Safe, yes, but almost always within the view of their owner.
- Chemistry Set
  - Sacrifice a syringe to identify that type.
  - Way to cook drugs? 
- Dumpster
  - Very durable
  - Hideable like Bush
- Oil Barrel 
  - A Rust-colored barrel which creates an oil pool when destroyed.
- Kitchen Fryer 
  - When destroyed, leaves a pool of oil.
- Pay Phone 
  - Call the Resistance to send a Specialist over. Choose between Hacker, Thief, and Goon. 
  - If Faction mod is a thing, get someone faction-specific.
  - Should be broadly multi-use.
- Security Door 
  - Indestructable
  - Not openable with lockpick or crowbar. 
  - Can only be opened via a connected computer.
- Trampoline 
  - Does annoying jumping behavior. I hate it already.
- Other Objects
  - Simply for visual variety when making custom chunks. Statues, park benches, filing cabinets, glass tables, office chairs, paintings, gym equipment, beer taps, curtains, etc. 

## Traits

- Adrenaline rush: gain strength for 5s after a kill.
- Alcoholic - Might be interesting to have an Addict trait but with alcohol.
- Animal Whisperer - Gorillas and Werewolves are Loyal
- Aquaphobia - take damage in water
- Arrogant - People get mad at you a lot more easily
- Arthritis - Your weapon swing and fire rate are slower. Cancels: Stubby fingers, sausage fingers, near harmless, pacifist.
- Banana Lover ++: You can't eat anything but bananas, but when you do, you do a fun lil' dance // Cost: $1200
	Need more stupid joke traits
- Bonkist - Backstabbing with a blunt weapon leaves the target Dizzy, if they survive. 
  - Considering making this a small chance with all blunt hits, not just backstabs
- Chemical resistance - status effects cannot affect you
- Double-Tapper: Ranged weapon equivalent to Backstabber, but only works in close range.
- Eye Poker - Chance to blind enemies when you hit them with an Unarmed attack.
- Far-Sighted
  - Can only use Ranged weapons
  - View distance increased (zoom out?)
- Fast Metabolism - Less healing from food and alcohol.
- Fatass
	- Slower movement
	- Can't wear armor
	- Stomp damage
      - This part was a can of worms. Suddenly you need a custom explosion type. Incredibly buggy.
- Generally Unpleasant - All NPCs start out Annoyed. 
  - Cancels: The Law, Random Reverance, Friend of the common folk, friend of the family.
  - Excludes Aligned and Prisoners.
- Good Arm - Increased Throw range.
- Hit-and-run: gain speed for 5s after a kill.
- Hungry Boy - More healing from food and alcohol.
- Infamous
  - Everyone except Cops, Goons, Scientists and Non-Humans are initially hostile to you. 
  - Cancels: Scientist Slayer, Specist, Blahd Crusher, Crepe slayer, Friend of the common folk, Random Reverence, Friend of the family.
- Machine Shaker - Chance of a free transaction when using a Vending Machine.
- Masochist - If 60 Seconds Pass Without Damaging Yourself, You Will Lose 3 Health Per 2 Seconds.
- Needy
  - You have needs like the musician, but they are not beneficial to you or anybody else. (You need to go to the toilet, etc)
  - You need to use the nice toilet. Which always happens to be in some inconvenient place like the closet of a gang hideout. That timer is rapidly ticking down, and if you don't go to that specific toilet, you'll have an accident, and no NPC or shop owner, etc will want to talk to you.
- Rap Sheet - Cops and Supercops start out annoyed with you.
- Separation Anxiety - If you have no followers, your stats are all lowered.
- Silent fingers - doing most actions produce significantly less noise, or no noise whatsoever, with the exception of alarms. (eg: arresting, breaking windows , enslaving, and (shooting guns?) make significantly less noise).
- Spectral Fist - You can hit Ghosts with your unarmed attacks. Extra damage to all Undead.
- Student of the Blade - Increased damage with Sharp weapons.
- Unsavable
  - Cannot heal, even through level ups. 
  - Cancels: Medical professional, strict cannibal, jugalarious, addict, [insert anything that heals you here.]
- Veiled Threats - When you attempt to Bribe, Extort, Mug, or Threaten, a failure will turn the target Annoyed instead of Hostile.
- Whiffist - Small chance for Melee or Thrown attacks to miss you completely.

#

# Extensions

Extensions of the behaviors of vanilla content.

## Accosting

Wandering NPC actions

- Cannibal - If you have CWC, they will ask to take a bite of you. You can agree or not. That's it.
- Cop - Might solicit a little bribe. If you have Cop Debt, it goes towards that total.
- Gang Member - Will attempt to mug you like Mobsters, but for a smaller amount ($15 * gang size).
- Jock - Might decide to punch you in the face. You know, as a prank.
- Office Drone - Will blab about sports. You can choose to blab back and get a new relation, from Annoyed to Loyal.
- Slum Dweller
	- Will occasionally beg you for money. Percent chance of outcome based on donation:

|Donation	|Hostile	|Annoyed	|Neutral	|Friendly	|Loyal		|Aligned	|Item Equivalent	|
|----------:|----------:|----------:|----------:|----------:|----------:|----------:|------------------:|
|$0			|10			|55			|35			|0			|0			|0			|N/A				|
|$5			|0			|5			|25			|65			|5			|0			|Fud				|
|$10		|0			|0			|5			|65			|25			|5			|Cigarettes or Beer	|
|$20		|0			|0			|0			|45			|45			|10			|Whiskey			|
|$50		|0			|0			|0			|0			|0			|100		|Sugar				|
|"Fuck off"	|100		|0			|0			|0			|0			|0			|Banana Peel		|

  - When done, randomly generate dialogue:
	- "i can feel the shadows consuming me, quck i need your cash!"
	- "Gimme money so i can have my last fix before rapture 2.0 destroys us all!"
	- "c'mon you gotta protect me, the Illuminati spy-cams are coming!"
	- "they injected me with liquid Antichrist"
	- "fud 0 is real! Help fund my research to figure out where big fud is hiding it!"
	- "i control the elements! Gimme your money or perish!"
	- Alignment line: (only on a level that is a multiple of 2: EG: 1-2, 2-2, 3-2...) "Can't you feel it? a disaster is coming!"
	- Alignment line: "the gates of [silly call of Cthulhu sounding name] are going to open any second now, i can feel it!"
	- Alignment line "i can see them... the bars above peoples heads, theyre up to something, i know it!"
	- Alignment line:"beds are too soft to be real, its a ploy to get us in our most vulnerable state!"
	- Alignment line: "I'm getting closer to finding the big brother that watches over us all, i just need to figure out what 'someone' is code for..."
	- imma refer to lines where they aggro on you cus you gave them food or didnt pay them as aggro lines
	- Aggro line: "Illuminati scum!"
	- Aggro line: "i knew it! You captured michal jackson, didnt you? WHERE ARE YOU HIDING HIM?!?"
- Scientist 
  - Asks you to take part in an experiment. 
  - If you agree, gives you a random status effect and $20.
- Wrestler
  - Challenges you to a duel, just like the player character. 
  - If you refuse, he gets annoyed.

## Fear

- Extended triggers for NPC "fear" behaviors
  - Killing their teammates
  - Eating or givving corpses 
  - Some NPCs unable to feel fear - robots, zombies, etc.

## NPC Interactions
- Bouncers
  - You can come in if for free if they see you smoke cigarettes. Because obviously it means you're cool.
- Cops  
	- Bribe is a % chance to succeed, annoy, or turn them hostile.
- Cop Bot
  - Tamper to deactivate them (Requires One Happy Tamper or Tech Expert). Maybe this will be a % chance for them to trust you, like robbing/extorting.
- Scientists
  - Hire to put poison in a Vent
- Thieves
  - Hire to unlock Safes
  - Hire to pickpocket
- Workers
  - Hire to Tamper

## Object Interactions
- Refrigerator 
  - Tamper to make it Run after a 10s countdown
- Safe 
  - Open with Detonator.
- Television 
  - Tamper to make it increase in volume immediately, and explode after a 10s countdown

#

# Overhauls

Any additions that include a variety of content, enough that they'd be considered sub-systems within the game.

## Drunkenness

- Trait: Low tolerance to alcohol - When you drink to much beer you will get the drunk status and you accuracy and melee will go down temporarily but you can recover easily and if you just overdrink you can end up bafing removing all of you status effects wich is both good and bad (for example if you have poison this can save you)
- Trait: Bar Brawler - If you drink to much you will get drunk which gives you a + on melee
- A golden trait for the robot Alcohol Energy Source makes "alcohol into energy"
  - Drinking while already at full hp gives you some seconds in the energy level but it cannot make you go up by a level so it just gives you seconds.

## Election Rebalance

The goal in this overhaul is to make winning the election a viable goal for any playstyle. In the vanilla game, getting elected requires a very narrow set of behaviors.

### Option A: Reputation Carryover

- Depending on your ending electability for a District, NPCs will have a starting attitude on later floors:

	| Reputation | Effect  |
	|:----------:|:-------:|
	| -10        | Hostile |
	| - 9 to - 5 | Annoyed |
	| - 4 to + 4 | Neutral |
	| + 5 to +10 | Friendly|
	| +10 to +15 | Loyal   |
	| +15        | Aligned |

- Affected NPCs by district:

	| District   | NPCs					|
	|:-----------|:---------------------|
	| Slums      | Gang Members			|
	| Industrial | Workers				|
	| Park		 | Gorillas, Cannibals	|
	| Downtown	 | Bouncer				|
	| Uptown	 | Upper Cruster		|

### Option B: Faction Reputations

- Same as Reputation Carryover, but influenced by behaviors

| Faction		| Members										| Enemies							|
|:--------------|:----------------------------------------------|:----------------------------------|
| Blahds		| Blahds										| Crepes, Mafia, Police				|
| Crepes		| Crepes										| Blahds, Mafia, Police				|
| Mafia			| Mafia											| Crepes, Blahds, Police			|
| Police		| Police, Cop Bots, Supercops					| Crepes, Blahds, Mafia				|
| Proles		| Workers, Slum Dwellers, Clerks, Couriers		| Bourgeoisie						|
| Bourgeoisie	| Upper Crusters, Investment Bankers, Scientists| Proles							|

- Actions that affect reputation:
 - Killing members of faction and its enemies
 - Net reputation among faction at end of level

### Option C: Merge A&B, have them both active

- This would make reputation a complex thing, but still ignorable/playable by all playstyles.

## Hacking Overhaul
Greatly increase the possibilities, risks, rewards, and trait investment for hacking

### Ground Rules
- *Attempt*: Every action while hacking has a % chance of success displayed next to its button. 
- *System*: The collection of Objects under one Owner ID in a particular chunk that has a Computer. If there's no Computer, the object is a System unto itself.
- *Heat*: This is a baseline increased difficulty to all Attempts in a System. It is increased whenever you pass an Attempt, more when you fail one. Remote access leads to higher heat than using a machine in person. Some Objects when not part of a System will have their own Heat, like ATMs. Refrigerators, not so much.
- *Password*: Occasionally found in a Computer's owner's pocket. Might also be found hidden somewhere in a Computer. Submissive NPCs will give you their passwords. Pretty much a Safe Combo except for Computers.
- *PayData*: Questgivers will occasionally request this, which you need to retrieve from an intact Computer. Hackers will buy PayData, sometimes a better offer than completing your Quest. PayData has a small chance of appearing without a Quest attached.
- A failed Attempt in a System may have different results, depending on how much your Attempt failed by, compared to Heat:
	1. Can reattempt, Heat+.
	2. Action Locked, Heat++.
	3. Action Locked, Heat++, any Hacker owners search.
	4. Action Locked, Heat+++, triggers Alarm, owners search.
	5. System Locked, Heat++++, triggers Alarm, owners search, and a squad of Cop Bots is deployed to search for you.
	6. Computer is destroyed, triggers Alarm, owners search, and a squad of Cop Bots is deployed to search for you.

### Traits
- Tech Expert is replaced by several traits. What's not in here is covered by Explosives Expert and Mechanical Expert (separate overhauls)
- *Cyber-Intruder* - Improve your Attempt rolls.
- *Data Broker* - Increase sell price of PayData, and its chance of appearing in a System.
- *IOT God* - Enables non-Computer Object hack actions. Many of the vanilla hack actions (Like "Refrigerator Run") would be hidden behind this trait.
- *IP Ghost* - Reduces initial Heat & slows its increase.

### Generic Computer Actions
- Access PayData: Relatively difficult but valuable, so you'll probably need to make sure you're prepared.
- Access System: The initial entry to a System is technically an Attempt. This also applies if you're trying to acces a system that has been Locked.
- Lights: Turns on or off all Lights in the Chunk. (See Stealth Overhaul)
- Cut Power: Shuts down the power for the Chunk. Can be brought back up with a Generator or Power Box.
- Deactivate Alarm: Just what it sounds like.
- Enter Password: Deactivates System's Heat permanently, but you can still roll an Attempt failure!
- Guess Password: A very small chance. Feeling lucky?
- Increase Permissions: Improves success rate of all further Attempts in the system, but slightly increases your Heat.
- Invert Credentials: Immediately flip the ownership of all cameras and turrets at once.
- Maintenance Mode: Disable Heat on a target Object in the System.
- Recover Password: Very high-risk.
- Route IP: Select another computer in the vicinity to route your access through. If Cop Bots are deployed, they'll go there instead.
- Trigger Alarm: Just what it sounds like.
- Unlock Action: Unlocks most actions previously locked (Except Wipe Audits). Increases Heat substantially.
- Wipe Audit Trail: Reset's Systems Heat to 0. Can only be done once per System.

### Chunk-specific Computer Actions
- Apartments - Sprinkler Test: All Stoves in the chunk leak oil for a few seconds, then burst into flames.
- Arcade - Cash Out: Unlock cash compartments in all Arcade Games, Jukeboxes, Pool Tables in the chunk. Each has $3-$5 inside. All become busted, though. Show Off: Any Hackers in the chunk become Loyal to you.
- Arena - Audience Participation Night: Release Rage Poison in vents.
- Armory - Red Alert: Cameras and turrets target everyone, gas is released, alarms go off continuously, huge explosionafter countdown.
- Bank - High chance of PayData. Heist Alert: Cause Supercops to swarm the level, searching the Bank first.
- Bar - Drink Specials: Buying a round is cut to half-price.
- Bathhouse - Deep Cleanse: Poison the water.
- Bathroom - Brown Alert: All toilets self-destruct with a Poison explosion.
- Broadcasting Station - ___?
- Cabin - Play Music (https://www.youtube.com/watch?v=puVYtkh-LO4)
- Casino - Card Counter: All owners become Annoyed at the targeted NPC. Card Cheat: All owners become Hostile to the targeted NPC.	 
- Cave - ___?
- Church - ___?
- City Park - Block Party: All NPCs who were wandering the level are now wandering this chunk. 
- Confiscation Center - ___?
- Dance Club - Now Punch to the Left: Mind control everyone dancing like the Alien's improved SA.
- Deportation Center - ___?
- Drug Den - He's Wearing a Wire: Owners become hostile to all non-Owners in the chunk. Codeword Flamingo: A small squad of Cops invades the chunk.
- Farm - Overclock Produce: All Trees, Bushes, Plants & Giant Plants in the chunk burst into flames after a countdown.
- Fire Station - Union Strike: Firefighters no longer put out fires in this level. Training Exercise: Release an Arsonist into the level. 
- Gated Community - Eek! Poor People!: One or two Supercops start wandering this chunk, wandering on patrol. 
- Graveyard - Where's the Good Stuff Buried: Increase your chance of finding Money when destroying a Gravestone.
- Greenhouse - Sup-R-Gro Treatment: Release Gigantizer gas in vents.
- Hedge Maze - Code Theseus: Werewolf Squad starts patrolling this chunk, hostile to anyone.
- Hideout - ___?
- Hospital - Emergency Pandemic Response: Release Cyanide gas in vents.
- Hotel - Premium Continental Breakfast Extravaganza: Get a banana.
- House - Silent Alarm: Summons a couple of cops to investigate the Chunk. They may or may not kill the homeowner depending on, you know... "factors."
- Ice Rink - Overclock A/C: Releases Freezy Gas from the Vents. 
- Lab - Delta Experiment: Releases a random Gas from the Vents. 
- Mall - Raise the Rent: All Vendors have a slight discount.
- Mansion - Amazon Order: If the Owner is alive, a Slave is generated for them. The People's Mansion: A swarm of Slum Dwellers invades the chunk.
- Mayor's House - ___?
- Mayor's Office - ___?
- Military Outpost - Strangelove Protocol: Owners are Hostile to everyone else.
- Movie Theater - ___?
- Music Hall - Mandatory Moshpit: Berserk everyone in the chunk, as long as Speakers, turntable, and Musician are still intact. Go to 11: Blows wind like the Air Gun from Speakers, deafens like the flute.
- Office Building - Extremely Casual Friday: Owners all become naked and Friendly.
- Pit - ___?
- Podium Park - Intro Music: Everyone assembles here before the podium is used. Might be a good distraction.
- Police Outpost/Police Station - All Clear: Set all Hostile Police to Annoyed. APB: All Police hostile to a target person. Lockdown Protocol: Deactivate or Activate Lockdown walls.
- Prison - Prisoner Discipline Initiative: Owners break into cells one by one and kill the inhabitants.
- Private Club - VIP Card: Gain Bouncer access. Owners are Loyal, others are Friendly.
- Shack - Blahd Bash / Crepe Crush: All gang members of a chosen type converge on this shack. If they don't see hostiles, they leave and resume their previous activities.
- Shop - Raise the Rent: All Vendors have a slight discount.
- Slave Shop - Free Slaves; Detonate Slaves
- Uptown House - Silent Alarm: Summons a couple of cops to investigate the Chunk. They may or may not kill the homeowner depending on, you know... "factors."
- Zoo - Animal Liberation Front: A squad of Gorillas invades the chunk and kills the owners.

### Object hacking Actions (Why IOT is a bad idea)
- Air Conditioner - Release Gas can now be done directly from A/C.
- Alarm Button - ___?
- Ammo Dispenser - On the House: One free Refill. Red Alert: Shoot bullets everywhere and explode
- Arcade Game - Cash Out: Release $3-5
- ATM - No longer Tossable nor destructible with melee, fire or bullets. Good chance of PayData. High heat, and alarm sensitive to hacking & tampering. Cash Transfer: Release ~$100. 
- Augmentation Booth - Dispense a free can of XP Juice.
- CloneMachine - Spit out a shapeshifter
- Crusher - Increase crush speed; Deactivate
- Door - If it has an Alarm or trap (See Alarm overhaul), reset/set off/deactivate it.
- Elevator - ___ ?
- FireSpewer - Deactivate; Leak Oil; Start; Overheat (nonstop fire and explosion)
- FlameGrate - Deactivate; Leak Oil; Start; Constant flame mode
- Generator - Activate/Deactivate (Similar to PowerBox, local to Chunk)
- Generator2 - Activate/Deactivate/Overload (Similar to PowerBox, local to Chunk)
- Goodie Dispenser - Maybe just replace this with a Shop machine - works like Shopkeeper. Goodie Dispenser sucks.
- Jukebox - Cash Out: Release $3-5
- Lamp - Separate Ground Wire: Electrocutes anyone who touches it. 
- LaserEmitter - Activate/Deactivate; Change Mode
- LoadoutMachine - ___?
- LockdownWall - Activate/Deactivate/Disable
- MetalDetector - ___?
- Mine - Deactivate for pickup; Detonate; Incendiary Mode
- PawnShopMachine - ___?
- PoliceBox - ___?
- PoolTable - Cash Out: Release $3-5
- PowerBox - Reactivate if shut down
- Refrigerator - Dispense Ice: Shoots Freeze Rays in random directions, then explodes.
- Safe - ___?
- SatelliteDish - ___?
- SecurityCam - ___?
- SlotMachine - Cash Out: Release ~$100. (Needs balance: ideas?)
- Speaker - Go to 11: Blows wind like the Air Gun, deafens like the flute.
- Stove - Overload Gas Line: Leak oil for 5s, then burst into flames.
- Television - Ludovico Protocol: Mind Control a person within visual range of the TV.
- Turntables - Mandatory Moshpit: Berserk everyone in the chunk, as long as Speakers, turntable, and Musician are still intact.
- Turret - ___?
- WaterPump - ___?
- Window: If it has an Alarm or trap (See Alarm overhaul), reset/set off/deactivate it.

## Magic Special Abilities
- Chronomancy
	- Uniques
		- Increase your attack speed
		- Normal attack speed when time is slowed down - fast punch like Goku
- Morphomancy
  - Assume the appearance of someone else, and gain all of their relations to other NPCs
	- Having someone else's appearance costs 5 mana per second
	- Miscasting turns you into a gorilla temporarily
- Pyromancy
	- Custom Firebomb explosion without glass sound
		- This was a can of worms when I tried it with HammerTime. All we need is to stop the glass sound, so maybe that'l be simpler.
	- Fan of Fire - 3 flames per shot // Fan of Fire + - 5 per shot
	- These should both be set to an angle proportionate to their speed. If the speed is high, keep them narrow. If it's low, keep them wide and more like a fan. They also decrease 
	- Ring of Fire - Shorter range, but 360 degrees
- Fireball
	- Would need a new Projectile type
- Hematomancy 
	- Blood Magic
- Kinetomancy  
	- Telekinesis
- Megaleiomancy 
	- Charm Person
- Necromancy
	- Normal Use
		- 1 Summon hostile Zombies from corpses / Turn ghosts into small number of crystals
		- 2 Zombies are Neutral to you / Turn ghosts into medium number of crystals
		- 3 Zombies will join your party / Turn ghosts into large number of crystals
		- When close to a ghost, you can turn them into mana crystals
	- Miscast 
		- turns all of them hostile, or summons hostile ghosts
	- Also:
		- https://www.reddit.com/r/streetsofrogue/comments/lhdwnx/my_third_entree_for_medieval_themed_characters/
- Telemancy
	- EMP on teleport?
	- Stun on teleport?

## Mugging & Extorting

- Request: Add a 0.5s delay between mugging failure and attack
- Trait: Beggar 
  - Works like Mugging, but lower-stakes.
- Mugger
  - Dealing damage to a refusing victim can make the target Submissive. 
  - Mugging is treated as a violent crime by police.
  - Mugger+ - When mugging someone, you get their inventory items too. 
- Extortionist 
  - Property owners will be more reluctant to give into extortion based on how much property they own.
  - Destruction of property and followers will make target more likely to go submissive, just like hitting them would.

## Path Traits

Not sure whether it's better to categorize these as acts or Paths. Paths would be a set of bonus/malus XP events for particular acts in a category.

- Chaotic Acts
	- Break Tombstone
	- Bribe Police
	- Influence Election
	- Mugging
	- Extortion
	- Install Malware
	- Kill non-Guilty NPC (Have guilty-vision)
	- Burn Walls
	- Set Fire
- Orderly Acts
	- Arrest Guilty NPC
	- Kill Guilty NPC
	- Knockout Guilty NPC
	- Extinguish Fire
	- Goon Quest
- Kind Acts
	- Offering Motivation
	- Spreading Happy Waves
	- Giving money to begging Slum Dwellers (planned feature)
- Just Acts
- Unjust Acts
	- Kill fleeing enemy
	- Kill Sleeping NPCs
	- Mugging
	- Possession
	- Extortion
- Fire Acts
	- Kill Fireman
	- Kill anyone with fire
	- Burn object
	- Burn corpse
	- Burn wall
- Water Acts
	- Put out fire
- Acts of Commerce
	- Spend Money
	- Get Money
- Uncategorized Acts
	- Use of Poison Syringe, Cyanide, Rage Poison, Haterator
	- Cannibalism, Blood Drinking
	- Use of Confusion Syringe, Sleep Darts, Chloroform

- Path of Blood
  - + Gib unburnt corpse or living enemy
  - - Burn corpse
- Path of Fire
  - You can only regain health by burning corpses. 
  - Take damage in Water.
  - Firefighters are always hostile and will use their water cannons against you.
  - Perpetual Particle Effect on character - flames or smoke
  - Big Quest - Burn a certain number of corpses
- Path of Shadow
  - +No Alarms
  - -Alarms
  - +Backstabbing
- Path of Justice - Basically just Cop XP portion split off for smaller trait
  - +Arrest Guilty
  - +Kill Guilty (less)
  - -Kill innocent
  - +Freeing Slaves or Gorillas

## Rap Sheet

- Guilt
  - If there's a Computer in a Police Station, and an Annoyed or Hostile Cop stops chasing you, they'll go there and enter your information into the database. If they're successful, all cops on the level will match their attitude towards you if theirs isn't currently worse.
  - Alternatively, if any of the above are hostile when you complete a level, you will gain Wanted for the next level.
- Absolution
  - You can hack the Police Station's computer to call off the APB, restoring your relationships to the cops to normal. There should be some drawback to this.
- Fines & "Fines"
  - If a cop sees you commit a minor crime, he will become Annoyed as usual and issue a warning. You can pay a Fine with him to remove the Annoyed status.
    - Alternatively, add any cop-witnessed property damage to Cop Debt?
  - If a cop sees you commit a major crime, there is a small chance he will ask you for a bribe instead of going hostile.
- Doughnut 
  - Moderate healing if consumed
  - Give to Neutral cops to make them Friendly
  - Give to Annoyed cops to avoid paying a Fine

## Scary Guns
  - Mechanics
    - Bullets are smaller, faster & deal more damage
    - Accuracy reduced while moving, & for followup shots due to recoil
    - Chance to inflict Slow for 1-2 seconds based on weapon damage
    - Armor plays a larger role in not dying
    - Characters have higher accuracy when standing on darker tiles. 
    - Characters in brighter tiles have a slightly lower chance to be protected by cover. This includes their own muzzle flash.
  - Ranged Skill
    - Increases accuracy, particularly when moving
    - Increases ROF
    - Reduces Windup
    - NO effect on gun damage
  - Cover
    - Most furniture that used to ignore bullets can now serve as cover. This includes broken windowframes.
    - A character shooting a gun has a chance to shoot past a Cover object. This chance is determined by how close they are to the object, their Ranged skill, and the particular stats of the object (easier to shoot past a chair than a vending machine)
     	- This means that you may take Cover behind objects by staying close to them, enabling you to shoot past them.
    - Softer objects are unlikely to stop bullets, but may weaken or divert their path.
    - Cover objects have various chances of having the following effect when hit by a bullet:
      - Destruction: Object to be damaged or destroyed by bullet
      - Obstruction: Chance to be hit by a bullet if at Cover range. 
      - Slow: Slow the bullet and reduce its damage
      - Divert: Divert the path of the projectile by a few degrees. https://en.wikipedia.org/wiki/Ricochet for variable list, pretty good info.
      - Block: Block the projectile entirely.
  - Legality:
    - Certain guns and gun mods are not legal. They will be treated as contraband by cops and cop bots. A legal gun with an illegal gun mod becomes illegal.
    - Smaller guns are able to serve as "holdouts," allowing you to conceal them from a search if you have the right trait.

### Guns

All scores here are relative to Pistol, considered to be roughly like a full-size 9mm handgun.

| Gun				|Dmg	|Acc	|ROF	|Recoil	|Noise	|Flash	|Legal	|Holdout|Default Mods	| Notes													|
|:------------------|:-----:|:-----:|:-----:|:-----:|:-----:|:-----:|:-----:|:-----:|:--------------|:------------------------------------------------------|
| AR				| +		| +		| ~		| -		|++		|++		|✓		|		|				|														|
| LMG				| ++	| ++	| ++	|+++	|+++	|+++	|		|		|Rifle Stock	| Accuracy greatly reduced if stationary				|
| Pea-Shooter(.22)	| -		| +		| +		| ---	|---	|---	|✓		|✓     |				| 														|
| PDW				| -		| --	| +++	| +		|-		|~		|		|✓     |				| 														|
| Rifle				| +++	| ++	| -		| +		|+++	|+		|✓		|		|Rifle Stock	|Windup before firing									|
| Pistol			| ~		| ~		| ~		| ~		|~		|~		|✓		|		|				| 														|
| Revolver			| ++	| + 	| --	| +		|+		|~		|✓		|		|				| 														|
| Shotgun			| ++	| ~		| -		| +++	|+++	|+		|✓		|		|Rifle Stock	| 														|
| SMG				| ~		| -		| ++	| ++	|~		|~		|		|		|				| 														|

### Gun Mods

| Mod				| Pistol|Revolver|Shotgun| SMG| AR| LMG| .22| PDW| Rifle|Illegal|Slot	 | Effect											 						|
|:------------------|:-----:|:------:|:-----:|:--:|:-:|:--:|:--:|:--:|:----:|:-----:|:------:|:-------------------------------------------------------------------------|
| FMJ Ammo			|✓		|✓      |		 |✓  |✓ |✓  |✓  |✓	 |✓    |       |Ammo    |Lower damage, but ignores armor											|
| JHP Ammo			|✓		|✓      |		 |✓  |✓ |✓  |✓  |✓  |✓    |       |Ammo	 |Increases damage, but much weaker against armor							|
| +P Ammo			|✓		|✓      |✓     |✓  |✓ |✓  |✓  |✓  |✓    |       |Ammo	 |Increases damage & projectile speed, increases recoil						|
| Slug Ammo			|       |        |✓     |    |   |    |    |    |      |       |Ammo    |Replaces buckshot with one large, deadly bullet							|
| Bipod				|		|        |		 |	  |✓ |✓  |    |    |✓    |       |Fore	 |Increases stationary accuracy.											|
| Foregrip			| 		|        |✓     |✓  |✓ |    |    |✓	 | 	    |       |Fore	 |Shotgun: Increase fire speed. Other: Reduce recoil.						|
| Hacksaw			|		|        |✓     |	  |	  |	   |    |    |      |✓		|Fore	 |Expands weapon spread, and damage at close range.							|
| Ammo Stock		|✓		|        |✓	 |✓  |✓ |✓  |✓  |✓  |✓    |       |Magazine|																			|
| Flash Hider		|✓		|✓      |✓     |✓  |✓ |✓  |✓  |✓  |✓    |       |Muzzle	 |Muzzle flash reduced														|
| Muzzle Brake		|✓		|✓      |       |✓  |✓ |✓  |    |✓  |      |       |Muzzle	 |Reduces recoil															|
| Silencer			|✓		|✓      | 		 |✓  |✓ |	   |✓  |✓  |✓    |       |Muzzle  |Effect highly dependent on weapon type									|
| Red Dot			|✓     |✓      |✓	 |✓  |✓ |	   |✓  |✓  |✓    |       |Sight	 |Reduces accuracy penalties of movement and follow-up shots				|
| Scope				|		|✓      |✓	 |	  |✓ |	   |    |    |✓    |       |Sight	 |Reticle can go further. Increases stationary accuracy. Slower zeroing		|
| Pistol Brace		|✓     |✓      |       |✓  |✓ |    |✓  |✓  |      |       |Stock   |Reduces recoil slightly.													|
| Rifle Stock		|		|		 |✓	 |	  |✓ |✓  |	|	 |✓	|		|Stock	 |Reduces recoil substantially; Slower zeroing								|
| Autofire Mod		|✓		|        |✓	 |	  |✓ |	   |✓  |    |      |✓     |Trigger |Full auto fire.															|
| Binary Trigger	|✓		|        |		 |	  |✓ |	   |✓  |	 |	    |       |Trigger |Fires two shots in fast succession.										|
| Anti X-Ray Spray	|✓     |✓		 |✓     |✓  |✓ |✓  |✓  |✓  |✓    |       |   -	 |Gun is undetectable from metal detectors.									|
| Accuracy Mod		| 		|        |		 |	  |	  |	   |    |    |      |       |	-	 |Removed																	|
| Rate of Fire Mod	| 		|        |		 |	  |	  |	   |    |    |      |       |	-	 |Removed																	|

### Traits 
  - Holdout Master: You can hide certain weapons from a search.

## Stealth Overhaul

- Visual detection
  - This would be an extension to Rogue Vision, or would at least carry the same rules as an assumption
  - Variable name is called "hardToSeeFromDistance", trait is same but capitalized
    - base = 1
    - Blends in Nicely or Goon = 1.7
    - Upgraded or Super-special = 2.5
  - Factors in detectable range:
    - Character Size
    - Noise
    - Light
    - Sight range (increasable with traits)
- Sound
  - Visual indicators of where sounds are coming from. This would include doors opening/closing, security cameras swiveling, etc. 
- Light
  - Hack computer to switch off lights
  - Depending on the District, lights have a chance to be flickering. More frequent in Slums, decreases as you progress.
  - Destroying a generator shuts off Lights in the Chunk? 
    - How do you handle multiple buildings per chunk, or multiple generators per building? 
      - Too bad, so sad.
- Bodies
  - Seeing a body for the first time should send other property owners into full search mode (like when an alarm goes off while hacking). 
  - Any way to keep them in a longer panic state? Finding a body should be disastrous for stealth, not a momentary setback.
  - Maybe have Alarm buttons on every level, and they run to press one if they find a body. 
    - This would need to be a mutator to ensure these are spawned.
  - If they're unconcious, they'll wake them up after searching the area
- Misc
  - Hiding in a box should slightly reduce movement speed (by like 0.5)
  - A Mirror you can use to peek around corners.
  - A Special ability that places or picks up a Spy Camera for observing patrols
  - A moveable Scout Drone
  - The ability to see Cameras' field of vision if you've hacked them, or an item specific to that.

## Tampering & Physical Security
- Item: Door Locker (2) - Use on a Door to Lock it from both sides - activate the door to unlock it.
- Item: Screwdriver (1) 
  - A stabbing weapon slightly weaker than the knifeWould be used for extended tampering options.
  - Tampering: 
- Item: Wire Cutters
  - Deactivate cameras instantly with no chance of failure
  - Destroy Barbed Wire fences
  - Deactivate Door & Window alarms
  - Deactivate Turrets
- Alarms on Chests/Safes, Doors & Windows
  - Factors in generation chance
    - Exterior doors & windows
    - Jail Cell doors
    - Chunk Level 
    - Chunk Type
    - Security Tech in chunk (Cameras, Turrets, Traps, Computers)
  - Disabling
    - Raw attempt to disarm, 50%. 
    - Use Wire Cutters for a 100% chance.
    - Hack
    - Disable from Computer
    - Destroy the object and set the alarm off. 
    - Hire a Worker to tamper for you.

### New item Tampering opportunities
- Air Conditioning Unit
  - Release Gas without access to main computer 
- Toilet 
  - Maybe spray water like hydrant, useful for keeping hallways clear. Or maybe some other behavior, not sure yet.
- Bed 
  - Fucking explode if someone tries to sleep in it. Not sure if they go back to bed after awoken, though.

## Zombie Town
- BQ: Z-Team - Zombie disaster occurs every level. Kill all Zombies and all living people carrying the Z-Virus. You get a free Friend Phone per level.
- Item: Z-Virus - Infects anyone it touches with Z-Virus. For use in vents, pools, and water guns.
  - Extra option when Buying a Round with a bartender to give it to everyone in the bar

#

# Miscellaneous

- removing traits: the same way you can gain + traits in the level up, there should be a chance for removing traits too (maybe called - traits?)
  - eg: You're cannibal, level up and leave slums 1. You have a choice between I'm Outtie, Low cost jobs, and - Malodorous.
- Make all traits accessible through Character Creator
- Make Keys, Money & Safe Combos not take up a slot

#

# Shelved

Any stuff I've previously attempted but have decided not to work on for now.

- Chronomancy
  - Show Timescale in statuses
		A:	// interactingAgent.statusEffects.myStatusEffectDisplay.RefreshStatusEffectText();
			// Used as a void, just to refresh all active in list. Should be pretty simple.
			// Just make a postfix here that tacks the timescale message at the top of the list if possible.
			// However, you may need to make a new object of type StatusEffectDisplayPiece
		B:	// Might not even need a patch. First, try
			StatusEffectDisplay.AddDisplayPiece and .RemoveDisplayPiece
		C: BuffDisplay.AddStatusEffect

- General Bullet modding (Re Electromancy & others)
  - Unused variables:
    - string substance
    - int damageMod