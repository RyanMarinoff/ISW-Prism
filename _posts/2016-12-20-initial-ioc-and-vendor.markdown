---
layout: post
title: Base Model Structure
date: 2016-12-20 13:30:00 -0500
categories: blog update code mvvm ioc
---

# Initial IoC Work
I have looked up a good location for the tools needed to load and manipulate the
product data. A methodology called IoC (inversion of control) is what I was finding
as a good location. The implementation I will be using is the creation of static
partial classes within an ISW.IoC namespace containing static methods to be called
upon to load and process data. The ViewModel will call these functions to perform
the different operations onto the data.

# IDataLoader creation and mindset
I will split the data handling into separate themed classes. So far there is only
the IDataLoader, which will handle all the data loading functionality. I have
previous code within a private repository in a different location that contains a
work-up of loading the csv files downloaded from Volusion. I will implement a
similar method, splitting the code to a modular manner. I have uploaded the Vendor
processing start and the Process CSV functionality.

# Vendor Class Changes
To get this to work, I have modified the Vendor class to include access to the data.
I have also created a Vendor constructor. Within all Vendors, there must be an ID.
This ID is a positive integer. The Title and PoTemplate can both be blank, but
shouldn’t in the end. Automatic error correction will be implemented at a later date.

# The End of the Day
Due to a short day, I will be cutting this short and picking this up tomorrow.
Updates to the Wiki will be made after the initial IDataLoader is completed.