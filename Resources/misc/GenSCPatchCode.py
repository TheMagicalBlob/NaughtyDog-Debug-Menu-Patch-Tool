# Outputs Selection As C# Code For My Own Tool. (Screw You, Go Away)
#@author illusiony; Edited For C# By TheMagicalBlob
#@category _NEW_
#@keybinding 
#@menupath 
#@toolbar
import ghidra.util.StringFormat.hexByteString as hexx
if currentProgram.getImageBase() != toAddr(0x400000):
  print "Dumbass"

  
ElfPatch = True
  

Highlights = currentHighlight
Selection = currentSelection

if Highlights is not None:

  ByteIntializer = "byte[][] CustomFunctions = new byte[{}][];".format(Highlights.getNumAddressRanges())

  Index = 0
  ranges = str(Highlights.getAddressRanges)
  rawAddresses = ranges[ranges.find("[[") + 2:ranges.find("] ]>")].split("] [")
  Addresses = "int[] Addresses = new int[] {"
  ByteArrays = ""

  # Create Address Arrays, Then Byte Arrays
  for member in rawAddresses:
    Address = toAddr(member[:member.find(',')])
    ByteLength = toAddr(member[member.find(',') + 2:]).subtract(Address) + 1
    sAddress = toAddr(Address.subtract(toAddr(0x3FC000)))


    ## Get Function Name And/Or Comment
    if getFunctionAt(Address) is not None:
        Comment = getFunctionAt(Address).getName()
        Plate = getPlateComment(Address)
        if Plate is not None:
          Plate = Plate.strip()
          Comment += "(): {}".format(Plate)
        else:
          Plate = getPreComment(Address)
          if Plate is not None:
            Comment += "(): {}".format(Plate)
    else:
      Comment = getEOLComment(Address)
      if Comment == None:
        Comment = getPreComment(Address)
      if Comment == None:
        Comment = ""
    ##

    ## Append Formatted Addresses To int[] Along With Comments
    if ElfPatch == True:
      Addresses += "\n    0x{}, // {} (Mem: {})".format(sAddress, Comment, Address)
    else:
      Addresses += "\n    0x{2}, // {1} (.elf: {0})".format(sAddress, Comment, Address)
    ##

    ## Create Byte Arrays
    Data = getBytes(Address, ByteLength)

    arr = "CustomFunctions[{}] = new byte[] {} ".format(Index, "{")
    for byte in Data:
      arr = arr + "0x{},".format(hexx(byte))
    ByteArrays += "// 0x{2} {3}\n{0} {1};\n\n".format(arr[:len(arr) - 1], '}', sAddress, Comment)
    ##
    Index+=1
  #

  
  Addresses += "\n};"
  ByteArrays += "\n\n"
  
  print "\n{}\n{}\n\n{}".format(ByteIntializer, Addresses, ByteArrays)
#

elif Selection is not None:
  Address = Selection.getMinAddress()
  if getFunctionAt(Address) is not None:
    Comment = getFunctionAt(Address).getName()
  else:
    Comment = getEOLComment(Address)
    #if Comment == None:
      #Comment = getPlateComment(Address)
    #if Comment == None:
      #Comment = getPreComment(Address)
    #if Comment == None:
      #Comment = getPostComment(Address)
    if Comment == None:
      Comment = ""

  # Create Comment For Address
  sAddress = toAddr(Address.subtract(toAddr(0x3FC000)))

  if ElfPatch == True:
      AddrStr = "0x{}, // {} (Mem: {})".format(sAddress, Comment, Address)
  else:
      AddrStr = "0x{2}, // {1} (.elf: {0})".format(sAddress, Comment, Address)
      sAddress = Address  # I'm Lazy


  # Create Byte Array
  Data = getBytes(Address, currentSelection.getMaxAddress().subtract(Address) + 1)

  str = "new byte[] { "
  for fag in Data:
    str = str + "0x{}, ".format(hexx(fag))
  str = "{} {}; // 0x{} {}".format(str[:len(str) - 2], '}', sAddress, Comment)
  
  print AddrStr
  print str

else:
  print "ERROR: Nothing Selected Or Highlighted.\nProcess Aborted, Like The User Should've Been"





