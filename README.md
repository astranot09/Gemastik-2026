# Flint's No Waste Restaurant

## About Game
Flint's No Waste Policy is a cozy, casual management game where players run a restaurant by designing menus and managing food inventory to satisfy customer demand while minimizing food waste. Through inventory management and menu planning mechanics, players are encouraged to use ingredients efficiently and mindfully to keep food waste to a minimum.

This Game I made for Gemastik <br>
Game Engine = Unity 6000.0.60f1

## Team Contribution
| Name | Roles | Duration |
| :---: | :---: | :---: |
| astranot09 | Game Programmer & Game Designer | 14 |
| Stopit-m8 | Game Designer & Game Programmer | ... |
| raymondbenedict2802405245’s | Game Artist | ... |

## My Contribution (astranot09)
- Menu Preparation Logic (What menu that player set, How to read the menu that player set)
- NPC Order Menu (Is there any food trend, What food that player have and does it intersect with the trend, How to order, What happend if there is no food or ingredient, etc)
- Logic to make food coming to NPC when the ordered success.
- Recap Logic (How much the menu is being ordered, How much the Ingredient being used, etc)
- Statistic Logic (When the trend is coming, When the trend is changing, How to read the trend with the menu, etc)
- Bucket Logic (When the bucket full, How to fill the bucket, If full what happend, When the bucket can be used again).
- Animation UI Dotween

## Key Features

### Strategic Menu Planning
Select 2 to 3 featured menu items daily based on available inventory and market trends.

### Shop & Inventory Management
Purchase raw ingredients with unique expiration dates. Expired items turn into food waste!

### Statistic Food Trend
Adapt to changing market demands where customers favor specific dish categories, boosting demand and satisfaction.

### Zero-Waste Composting System
Process accumulated food waste in composting buckets to create organic fertilizer, mitigating popularity loss from waste.

### Reputation & Popularity Mechanics
High customer satisfaction boosts restaurant popularity, driving higher customer traffic.

## Layer / Module Design

<img width="1299" height="1813" alt="FlintModule drawio" src="https://github.com/user-attachments/assets/90e15b6c-8de6-4b4d-a760-5ee94d0977e1" />


## Modules and Features

| Name | Scene | Responsibility |
| :---: | :---: | :---: |
| Scene Controller | All Scene | Scene transitions, loading screens, state resets. |
| Audio Manager | All Scene | Plays BGM/SFX globally via audio database. |
| Cutscene Manager | Cutscene Intro | Handles sequence triggers, image lists, and DOTween cinematic animations. |
| Main Menu Manager | Main Menu | Manages menu UI navigation, options, and game startup routines. |
| Dialogue Manager | Gameplay | Handles typewriter dialogue rendering, speaker portraits, and narrative queues. |
| Statistic Manager | Gameplay | Generates food trends, tracks trend durations, and evaluates menu alignment. |
| Food To NPC | Gameplay | Controls food delivery animations and table targeting upon order completion. |
| Inventory Manager | Gameplay | Stores raw ingredients, updates item stacks, and ticks down expiration dates. |
| Shop Manager | Gameplay | Handles item purchasing, unit costs, and stock transfers to player inventory. |
| Currency Manager | Gameplay | Tracks revenue, applies profit multipliers, and evaluates daily financial targets. |
| Game Manager | Gameplay | Coordinates day-night cycles, service states, and customer spawning routines. |
| Lose Manager | Gameplay | Evaluates game-over triggers when financial targets fail. |
| Menu Manager | Gameplay | Tracks unlocked recipes in menu book. |
| Minigame Manager | Gameplay | TLaunches interactive minigames and evaluates rewards. |
| NPC Manager | Gameplay | Handles customer spawning, table assignments, and queue logic. |
| Order Manager | Gameplay | Processes NPC orders, validates inventory stock, and handles cancelations. |
| Popularity Manager | Gameplay | Dynamically scales customer traffic based on customer satisfaction and waste penalties |
| Recap Manager | Gameplay | Aggregates daily financial performance, ingredient usage, and waste generation. |
| Table Manager | Gameplay | Tracks dining table availability, and occupancy. |
| Waste Manager | Gameplay | Converts expired food into waste, monitors bucket capacity, and triggers composting. |
| Choosing Menu | Gameplay | Database of recipes and active menu selection during preperation. |
| NPC Choose Menu | Gameplay | AI logic evaluating trends, menu items, and customer preference. |
| Path Finding | Gameplay | Waypoint-based navigation for customer movement between entrance, tables, and exit. |

## Game Flow
<img width="1082" height="1487" alt="FlintGameFlow drawio" src="https://github.com/user-attachments/assets/49e20f2a-b8c9-41bb-b2f3-c6c1cf2932d9" />

