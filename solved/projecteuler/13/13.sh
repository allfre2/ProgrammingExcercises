#!/usr/bin/env bash

echo `xsel -b | sed 's/$/+/'`0 | bc | cut -c 1-10

