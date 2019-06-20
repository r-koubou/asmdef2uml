
## Generate a dependency graph tool for Unity Assembly Definition

![](https://i.gyazo.com/dfb29b0239c945f8964881fecd337ac0.png)

### Supported format

- [PlantUML](http://plantuml.com/) format

### Requirements

- .net Framework 4.0 or later
- [PlantUML](http://plantuml.com/)
	- Graphviz
	- Java Runtime

### Usage

~~~
Asmdef2Uml <scan directory> [exclude assembly name (Regex)]>out.txt
~~~

**\*Currently output a PlantUml code to only stdout.**

#### e.g.

1: Convert to PlantUML code format.

~~~
Asmdef2Uml C:\Hoge\Foo\Bar>out.txt
~~~

PlantUml code will be generated to "out.txt".

2: Use PlantUML to Convert to graphics file format.



### You can exclude files if you want

e.g.

~~~
Asmdef2Uml C:\Hoge\Foo\Bar .*Test.*
~~~

`.*Test.*` is written by Regex

