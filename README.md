# Linguisketch
Linguisketch is a simple language I have written that allows you to create images from text.

## Example
```perl
# This is a comment that will be ignored by the parser.
size 512 128

fillcolor black
fill 0 0 128 128

image 0 0 ./Resources/badge.png # You can also add comments on the end of lines.

strokecolor black
line 0 0 512 0
line 512 0 512 128
line 512 128 0 128

textsize 60
text 140 84 Linguisketch
```
### Output
![ExampleImage](https://cdn.discordapp.com/attachments/814444289181351968/1130304091667570718/rhwt0qqa.q4o.png)
