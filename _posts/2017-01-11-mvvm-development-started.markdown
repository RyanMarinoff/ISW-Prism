---
layout: post
title: MVVM Development Started
date: 2017-01-11 15:58:00 -0500
categories: blog mvvm
---

### Rethinking of Approach

After a bit of thinking, I have reset Views branch within the repository. Nothing was within there and a different approach will be implemented. I am holding back a bit on Prism.

### Property Change Functionality

I have added a property changed functionality to the models. The intent is to notify the program when the user has changed something, so that this is stored in the internal database to be exported upon closing the program or via an intended action by the user.

### First Refactoring

Refactored Product, ParentProduct and ChildProduct so that all member properties of Product are protected and all accessors of Product are virtualized so to be implemented within ParentProduct and ChildProduct. This process was a bit more difficult to get working properly and may need to be re-addressed once additional functionality is implemented.

### View and ViewModel Construction

Due to this being my first experience with MVVM, I am working with tutorialspoint.com/mvvm to construct the Views and View Models of the application. Using the techniques found here, I will create a preliminary setup of an application before refactoring to use Prism. My first attempt at using the tutorial series was not too successful, due to a lack of understanding of the frameworks used and mindset of the different techniques.

The first implementation includes listing of all products loaded into the application and calling a deletion command for each individual item.

### End of Day

Next up is to continue working with the tutorial to understand how to implement cross view data access and actions, changing of data, and displaying the different views within the application. Here and there a bit of re-working and learning will take place before a full implementation of the knowledge will be used. 
