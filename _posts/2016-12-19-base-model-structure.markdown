---
layout: post
title: Base Model Structure
date: 2016-12-19 14:30:00 -0500
categories: blog update code mvvm
---

# What is MVVM

MVVM is a programming structure that is used to organize and modularize the internal workings
of a program. This is the structure that Prism is based under. After doing a bit of research
on how to approach the programming of this application, this method of programming was chosen.
I am new at it, so this process will be a self taught process. I am going to place here the
work I have done, and why I have chosen the process. As far as the why of MVVM, a personal
choice. I like it!

MVVM means Model - View - View Model. Model is the structure of the data. This would include
the classes and code that represents the data, and only the data. View is the presentation of
the data to the user. This would include all the pieces and parts of the user interface,
modularized and organized based around the presentation of the different parts of the data.
View Model is the connection between the model and the view, the conversion of data to be
presented by the program. The model should not know how the data will be represented. The
model is just the data itself. The view should not need to know how the data is stored. It
is the presentation of the data to the user for the purpose needed. View Model will pull
from the Model, format the data as needed, and presents it to the View. The View binds the
fields within the presentation to the data that is presented by the view model. An image
would describe this process more clearly (or a reformatting of this post).

# Current Process

Basic structure of the models of the application has been completed. The following is a
quick bit of each models. For more information, check out the
[ISW-Prism GitHub Wiki](https://github.com/RyanMarinoff/ISW-Prism/wiki).

## Product

The product model represents the products found within the Reyers Volusion website. The
website contains a 'Parent Product' to represent the item that is ordered. This is what
the customer sees when they visit the product page. The 'Child Product' represents the
inventory items. With shoes, this will be the size / length combination of the product.
Each 'Child Product' is associated with a SKU within the internal database. Currently
this data is not available. Only the data from the site will be processed within the program.

## Option

Within the Volusion store front, the options are used to tie the physical inventory with the
internet inventory. Currently a raw porting of the information is used within the application.
Refinement will occur when use is determined beyond raw data.

## Category

Categories are used to determine how the products are displayed and organized on the site.
For purposes of this application, the Categories are used to determine multiple aspects of
product use and need. This model will need the most work to stream-line. Currently this is
just a data-dump.

## Vendor

Vendors are the manufacturers of the product. Volusion has a separate section within the
database for the vendor information. For this program, very little is currently needed for
Vendors. Bare minimum is used to represent the vendors.