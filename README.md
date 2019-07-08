
# Smart Town


### Introduction

Smart Town is a project that aims at spectating a town living at high scale
It can be useful to spectate the architecture of a town to see how people live in it and travel across it.

The idea is to implement a human that do basic stuff such as eating, buying food, going to job and clone it to have a city of many people living at the same time.

In the future, these people will be differenciated according to their personnality, their job, etc.

### Overview

I saw the architecture like a bunch of needs a human needs to fill according to priorities.

In my architecture, the human and the objects he owns have needs.

The human:

- Has to eat, hunger is always increasing and resets when he eats
- Has to wash himself, dirtyness is always increasing and resets when he washes

The objects get notified when being used, so that they can keep track of the resources it holds or whatever

The fridge for example:

- Needs to be refilled
  - The storage of the fridge gets down whenever it is used
- Needs to be repaired
  - Using the fridge increases chances of breaking it on the next use


When the human is wondering what he should do next, he takes in account his needs and the objects-he-owns needs. He then takes the highest priority and executes the _Need_

The need is a couple of variables indicating the time it takes to accomplish, its name, and its steps to accomplish it.

#### I. A Need

A need is a description of what has to be done to fullfill it.

It has a _name_ (Purely cosmetic)
It has a _time of execution_, for example eating will be 5 minutes
It has a _description_ of the steps it takes to be fullfilled
It has the _object_ it needs to be fullfilled

The steps available are:

- ACT: The _entity_ executes the task for the amount of time the need needs
- GO_HOME: The entity will head toward its house
- GO_TARGET: The entity will head toward the item it needs to act with

The object specified is a side object that the human needs to interact with to complete the need.

With all these steps, we can imagine shopping to fullfill the fridge to be like:

- Name: Shopping for food
- Time of execution: 30m (30 minutes to do the shopping)
- Object: Any object of type `Shop`
- List of steps: GO_TARGET, ACT, GO_HOME
  - Go to a `shop`, buy, go home

#### II. Human

> A human is an _entity_

The human has a _House_, useful to many needs refering to it.
It also have a needs _queue_ processing in order every task given to it.

It just orders all his needs and the ones of the objects he owns, then sort all of them by priority then executes the highest priority.

The execution of a need is handled by the queue which interprets the _needs_ as a succession of actions
