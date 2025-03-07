:: pre-build & post-build events don't run most of the time in either project, so this is a lazy manual fix.
xcopy "..\OrbisGP4\libgp4\bin\Release\libgp4.dll" "Resources\bin\" /v/y/f