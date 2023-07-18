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

## Documentation
| Command | Descriptions | Required |
| --- | --- | --- |
| `size <width> <height>` | Sets the size of the output image. | True |
| `strokecolor <color>` | Sets the stroke color of any stroke object. | False |
| `fillcolor <color>` | Sets the fill color of any fill object. | False |
| `fill <x1> <y1> <x2> <y2>` | Fills an spanning 2 sets of 2 dimensional vectors. | False |
| `image <x> <y> <path>` | Fetches image from path and embeds it into output image. | False |
| `textalign <alignment>` | Sets the alignment of any following text object (left, right, center) | False |
| `textsize <size>` | Sets the font size of any following text object. | False |
| `text <x> <y> <text>` | Prints text into the output image. | False |
